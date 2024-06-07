///////////////////////////////////////////////////////////////////////
// File:        tessnet2.cpp
// Description: .NET Assembly for Tesseract.
// Author:      Remi THOMAS
// Created:     21JUN08
// Version:		2.04.01 04JUN09 based on tesseract 2.04
// 
// (C) Copyright 2008, Pixel Technology.
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
///////////////////////////////////////////////////////////////////////
// tessnet2.h : The assembly implementation
//

#include "stdafx.h"
#include "tessnet2.h"
#include "..\ccutil\varable.h"
#include "..\cutil\tordvars.h"
#include "..\cutil\callcpp.h"
#include "..\cutil\variables.h"
#include "..\wordrec\metrics.h"
#include "..\wordrec\chop.h"
#include "..\wordrec\djmenus.h"
#include "..\wordrec\tessinit.h"
#include "..\wordrec\mfvars.h"
#include "..\ccmain\tessedit.h"
#include "..\ccmain\tessvars.h"
#include "..\classify\baseline.h"
#include "..\classify\adaptmatch.h"
#include "..\classify\mfoutline.h"
#include "..\classify\normmatch.h"
#include "..\classify\intmatcher.h"
#include "..\classify\speckle.h"
#include "..\dict\permute.h"

using namespace System::Runtime::InteropServices;

extern ESHM_INFO shm;

// Interesting API are protected, do a wrapper to have access to them
#pragma managed(push, off)
// http://social.msdn.microsoft.com/Forums/en-US/clr/thread/cd3c34a6-84f9-4e2b-a483-12e179eb84b7
class MyTessBaseAPI : public TessBaseAPI
{
public:
	void CopyImageToTesseract(const unsigned char* imagedata, int bytes_per_pixel, int bytes_per_line, int left, int top, int width, int height)
	{
		TessBaseAPI::CopyImageToTesseract(imagedata, bytes_per_pixel, bytes_per_line, left, top, width, height);
	}

	void CopyBinaryRect(const unsigned char* imagedata, int bytes_per_line, int left, int top, int width, int height)
	{
		TessBaseAPI::CopyBinaryRect(imagedata, bytes_per_line, left, top, width, height);
	}

	void FindLines(BLOCK_LIST* block_list)
	{
		TessBaseAPI::FindLines(block_list);
	}

	PAGE_RES* Recognize(BLOCK_LIST* block_list, struct ETEXT_STRUCT* monitor)
	{
		return TessBaseAPI::Recognize(block_list, monitor);
	}

	char* TesseractToText(PAGE_RES* page_res)
	{
		return TessBaseAPI::TesseractToText(page_res);
	}
};
#pragma managed(pop)

tessnet2::Tesseract::Tesseract()
{
	m_myTessBaseAPIInstance = NULL;
	m_pageRes = NULL;
}

tessnet2::Tesseract::~Tesseract()
{
	Clear();
}

int tessnet2::Tesseract::Init(String^ tessdata, String^ lang, bool numericMode)
{
	Clear();

	m_myTessBaseAPIInstance = new MyTessBaseAPI;
	// IntPtr _dataPath = Marshal::StringToHGlobalAnsi(dataPath);
	IntPtr _lang = Marshal::StringToHGlobalAnsi(lang);
	if (String::IsNullOrEmpty(tessdata))
		tessdata = nullptr;
	if (!String::IsNullOrEmpty(tessdata))
		tessdata += "\\dummy"; // The last directory is removed during the init, we need it so we add /dummy here
	IntPtr _tessdata = Marshal::StringToHGlobalAnsi(tessdata);
	if (tessdata!=nullptr)
		SetVariable("m_data_sub_dir", "\\");
	int result = m_myTessBaseAPIInstance->InitWithLanguage((char *)_tessdata.ToPointer(), NULL, (char *)_lang.ToPointer(), NULL, numericMode, 0, NULL);
	SetVariable("tessedit_write_ratings", true);
	//SetVariable("tessedit_zero_rejection", true);
	Marshal::FreeHGlobal(_lang);
	Marshal::FreeHGlobal(_tessdata);
	// Marshal::FreeHGlobal(_dataPath);
	return result;
}

void tessnet2::Tesseract::Clear ()
{
	page_image.destroy();
	if (m_pageRes)
		delete m_pageRes;
	m_pageRes = NULL;

	if (m_myTessBaseAPIInstance)
	{
		m_myTessBaseAPIInstance->End();
		delete m_myTessBaseAPIInstance;
	}
	m_myTessBaseAPIInstance = NULL;
}

bool tessnet2::Tesseract::SetVariable(String^ name, Object^ val)
{
	IntPtr _name = Marshal::StringToHGlobalAnsi(name);
	char *__name = (char *)_name.ToPointer();

	INT_VARIABLE_C_IT int_it(INT_VARIABLE::get_head());
	BOOL_VARIABLE_C_IT bool_it(BOOL_VARIABLE::get_head());
	STRING_VARIABLE_C_IT str_it(STRING_VARIABLE::get_head());
	double_VARIABLE_C_IT dbl_it(double_VARIABLE::get_head());

	bool bFound = false;

	for (int_it.mark_cycle_pt(); !int_it.cycled_list(); int_it.forward()) 
	{
		if (!strcmp(int_it.data()->name_str(), __name))
		{
			int_it.data()->set_value(Convert::ToInt32(val));
			bFound=true;
			break;
		}
	}
	
	if (!bFound)
	{
		for (bool_it.mark_cycle_pt(); !bool_it.cycled_list(); bool_it.forward()) 
		{
			if (!strcmp(bool_it.data()->name_str(), __name))
			{
				bool_it.data()->set_value(Convert::ToByte(val));
				bFound=true;
				break;
			}
		}
	}

	if (!bFound)
	{
		for (str_it.mark_cycle_pt(); !str_it.cycled_list(); str_it.forward()) 
		{
			if (!strcmp(str_it.data()->name_str(), __name))
			{
				IntPtr _val = Marshal::StringToHGlobalAnsi(val->ToString());
				str_it.data()->set_value(STRING((const char *)_val.ToPointer()));
				Marshal::FreeHGlobal(_val);
				bFound=true;
				break;
			}
		}
	}

	if (!bFound)
	{
		for (dbl_it.mark_cycle_pt(); !dbl_it.cycled_list(); dbl_it.forward()) 
		{
			if (!strcmp(dbl_it.data()->name_str(), __name))
			{
				dbl_it.data()->set_value(Convert::ToDouble(val));
				bFound=true;
				break;
			}
		}
	}

	Marshal::FreeHGlobal(_name);
	return bFound;
}

Object^ tessnet2::Tesseract::GetVariable (String^ name)
{
	Object^ result = nullptr;

	IntPtr _name = Marshal::StringToHGlobalAnsi(name);
	char *__name = (char *)_name.ToPointer();

	INT_VARIABLE_C_IT int_it(INT_VARIABLE::get_head());
	BOOL_VARIABLE_C_IT bool_it(BOOL_VARIABLE::get_head());
	STRING_VARIABLE_C_IT str_it(STRING_VARIABLE::get_head());
	double_VARIABLE_C_IT dbl_it(double_VARIABLE::get_head());

	for (int_it.mark_cycle_pt(); !int_it.cycled_list(); int_it.forward()) 
	{
		if (!strcmp(int_it.data()->name_str(), __name))
		{
			int tmp = *int_it.data();
			result = tmp;
			break;
		}
	}
	
	if (result==nullptr)
	{
		for (bool_it.mark_cycle_pt(); !bool_it.cycled_list(); bool_it.forward()) 
		{
			if (!strcmp(bool_it.data()->name_str(), __name))
			{
				System::Byte tmp = *bool_it.data();
				result = tmp;
				break;
			}
		}
	}

	if (result==nullptr)
	{
		for (str_it.mark_cycle_pt(); !str_it.cycled_list(); str_it.forward()) 
		{
			if (!strcmp(str_it.data()->name_str(), __name))
			{
				STRING tmp = *str_it.data();
				result = gcnew String(tmp.string());
				break;
			}
		}
	}

	if (result==nullptr)
	{
		for (dbl_it.mark_cycle_pt(); !dbl_it.cycled_list(); dbl_it.forward()) 
		{
			if (!strcmp(dbl_it.data()->name_str(), __name))
			{
				double tmp = *dbl_it.data();
				result = tmp;
				break;
			}
		}
	}

	Marshal::FreeHGlobal(_name);
	return result;
}

Dictionary<String ^, Type^>^ tessnet2::Tesseract::GetVariableList()
{
	Dictionary<String ^, Type^>^ result = gcnew Dictionary<String ^, Type^>();

	INT_VARIABLE_C_IT int_it(INT_VARIABLE::get_head());
	BOOL_VARIABLE_C_IT bool_it(BOOL_VARIABLE::get_head());
	STRING_VARIABLE_C_IT str_it(STRING_VARIABLE::get_head());
	double_VARIABLE_C_IT dbl_it(double_VARIABLE::get_head());

	for (int_it.mark_cycle_pt(); !int_it.cycled_list(); int_it.forward())
		result->Add(gcnew String(int_it.data()->name_str()), System::Int32::typeid);
	for (bool_it.mark_cycle_pt(); !bool_it.cycled_list(); bool_it.forward()) 
		result->Add(gcnew String(bool_it.data()->name_str()), System::Byte::typeid);
	for (str_it.mark_cycle_pt(); !str_it.cycled_list(); str_it.forward()) 
		result->Add(gcnew String(str_it.data()->name_str()), System::String::typeid);
	for (dbl_it.mark_cycle_pt(); !dbl_it.cycled_list(); dbl_it.forward()) 
		result->Add(gcnew String(dbl_it.data()->name_str()), System::Double::typeid);

	return result;
}

/*
void tessnet2::Tesseract::SetRootPath (String^ rootPath, String^ lang)
{
	SetVariable("tessedit_unicharset", rootPath + "\\" + lang + ".unicharset");
	SetVariable("tessedit_inttemp", rootPath + "\\" + lang + ".inttemp");
	SetVariable("tessedit_pffmtable", rootPath + "\\" + lang + ".pffmtable");
	SetVariable("tessedit_normproto", rootPath + "\\" + lang + ".normproto");
	SetVariable("tessedit_worddawg", rootPath + "\\" + lang + ".word-dawg");
	SetVariable("tessedit_userwords", rootPath + "\\" + lang + ".user-words");
	SetVariable("tessedit_freqdawg", rootPath + "\\" + lang + ".freq-dawg");
	SetVariable("tessedit_dangambigs", rootPath + "\\" + lang + ".DangAmbigs");
	
}
*/

void tessnet2::Tesseract::PutImage(System::Drawing::Bitmap^ bitmap, System::Drawing::Rectangle rect)
{

	// If empty rectangle then full page
	if (rect == System::Drawing::Rectangle::Empty)
		rect = System::Drawing::Rectangle(0, 0, bitmap->Width, bitmap->Height);

	System::Drawing::Bitmap^ tmp = bitmap;
	// Image with tranparency are transformed in 24bpp (Julien Benoit)
	if (Image::IsAlphaPixelFormat(bitmap->PixelFormat))
	{
		tmp = gcnew System::Drawing::Bitmap(bitmap->Width, bitmap->Height, Imaging::PixelFormat::Format24bppRgb);
		tmp->SetResolution(bitmap->HorizontalResolution, bitmap->VerticalResolution);
		System::Drawing::Graphics^ gr = System::Drawing::Graphics::FromImage(tmp);
		gr->DrawImageUnscaled(bitmap, 0, 0);
		delete gr;
	}

	int bpp=-1;
	if (tmp->PixelFormat == Imaging::PixelFormat::Format1bppIndexed)
		bpp = 0;
	else if (tmp->PixelFormat == Imaging::PixelFormat::Format8bppIndexed)
		bpp = 1;
	else if (tmp->PixelFormat == Imaging::PixelFormat::Format24bppRgb)
		bpp = 3;

	if (bpp>-1)
	{
		// Copy image and do threshold, using only the interessting part of the image
		Imaging::BitmapData ^data = tmp->LockBits(rect, Imaging::ImageLockMode::ReadWrite, tmp->PixelFormat);
		// BitmapData.Stride can be negative, if this is the case reverse the image
		BYTE *scan0 = NULL;
		int stride = data->Stride;
		if (data->Stride>0)
			scan0 = (BYTE *)data->Scan0.ToPointer();
		else
		{
			stride = -data->Stride;
			scan0 = new BYTE[data->Height*stride];
			BYTE *scan0b = (BYTE *)data->Scan0.ToPointer();
			for (int y=0; y<data->Height; y++)
				memcpy(scan0 + y*stride, scan0b - y*stride, stride); // Very strange, when stride is negative, Scan0 = last line
		}
		if (bpp==0)
			m_myTessBaseAPIInstance->CopyBinaryRect(scan0, stride, 0, 0, rect.Width, rect.Height);
		else
			// Convert image to 1 bit format doing threshold
			m_myTessBaseAPIInstance->CopyImageToTesseract(scan0, bpp, stride, 0, 0, rect.Width, rect.Height);
		if (data->Stride<=0)
			delete[] scan0;
		tmp->UnlockBits(data);
	}

	// Release tmp bitmap only if created here
	if (tmp!=bitmap)
		delete tmp;
}


List<tessnet2::Word ^>^ tessnet2::Tesseract::DoOCR(System::Drawing::Bitmap^ bitmap, System::Drawing::Rectangle rect)
{
	init_metrics();
	set_tess_tweak_vars();

	init_baseline();
    init_bestfirst_vars();
    init_splitter_vars();
    init_associate_vars();
    init_chop();
    init_textord_vars();
    init_permute_vars();

	// init_dj_debug();
	InitAdaptiveClassifierVars(); 
    InitMFOutlineVars(); 
    InitNormProtoVars(); 
    InitIntProtoVars(); 
    InitIntegerMatcherVars(); 
    InitSpeckleVars(); 
    InitStopperVars(); 

	program_variables();
	mfeature_variables();
	program_init();
	mfeature_init();
	init_permute();
	// setup_cp_maps();

	List<Word ^>^ result=nullptr;

	PutImage(bitmap, rect);

	shm.shm_size = sizeof (ETEXT_DESC)+32000L*sizeof (EANYCODE_CHAR);
	shm.shm_mem = new BYTE[shm.shm_size];
	ZeroMemory(shm.shm_mem, shm.shm_size);
	m_monitor = ocr_setup_monitor();

	// Now run the main recognition.
	if (OcrDone==nullptr)
	{
		doOCR();
		result = BuildPage();
		free_variables();
	}
	else
	{
		m_callbackThread = gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this, &tessnet2::Tesseract::doCallback));
		m_callbackThread->Start();
	}

	return result;

}

System::Drawing::Bitmap^ tessnet2::Tesseract::GetThresholdedImage (System::Drawing::Bitmap^ bitmap, System::Drawing::Rectangle rect)
{
	PutImage(bitmap, rect);

	int width = page_image.get_xsize();
	int height = page_image.get_ysize();
	System::Drawing::Bitmap^ result = gcnew Bitmap(width, height, System::Drawing::Imaging::PixelFormat::Format24bppRgb); // Not 1bpp because GDI+ doesn't handle them correctly
	Imaging::BitmapData ^data = result->LockBits(System::Drawing::Rectangle(0, 0, width, height), Imaging::ImageLockMode::ReadWrite, result->PixelFormat);
	BYTE *scan0 = (BYTE *)data->Scan0.ToPointer();
	IMAGELINE line;
	for (int y=0; y<height; y++)
	{
		page_image.get_line(0, y, width, &line, 0);
		BYTE *dest = scan0 + data->Stride*(height - y - 1);
		BYTE *src = (BYTE *)line.pixels;
		for (int x=0; x<width; x++) // Convert 1bpp to 24bpp
		{
			BYTE val = (*src++)*255;
			*dest++ = val;
			*dest++ = val;
			*dest++ = val;
		}
	}
	result->UnlockBits(data);
	return result;
}

void tessnet2::Tesseract::doOCR()
{
	BLOCK_LIST    block_list;
	m_myTessBaseAPIInstance->FindLines(&block_list);

	m_pageRes = m_myTessBaseAPIInstance->Recognize(&block_list, m_monitor);
	
	PAGE_RES_IT res_it(m_pageRes);

	/*
	for (res_it.restart_page(); res_it.word () != NULL; res_it.forward()) 
	{
		WERD_RES *word = res_it.word();
		WERD_CHOICE* choice = word->best_choice;
		String^ tmp = gcnew String(choice->string().string());
		Console::WriteLine("{0}:{1}:{2}", tmp, 100 + 5*choice->certainty(), choice->rating());
	}
	*/

	//char *text = m_myTessBaseAPIInstance->TesseractToText(page_res);
	delete[] shm.shm_mem;
}

void tessnet2::Tesseract::doCallback()
{
	m_ocrThread = gcnew System::Threading::Thread(gcnew System::Threading::ThreadStart(this, &tessnet2::Tesseract::doOCR));
	m_ocrThread->Priority = System::Threading::ThreadPriority::BelowNormal;
	m_ocrThread->Start();
	while (!m_ocrThread->Join(100))
		ProgressEvent(m_monitor->progress);
	OcrDone(BuildPage());
	free_variables();
}

List<tessnet2::Word^>^ tessnet2::Tesseract::BuildPage()
{
	List<Word ^>^ result = gcnew List<Word ^>();
	Word^ currentWord = nullptr;
	int j=0;
	int lineIndex=0;
	char unistr[8] = {};
	int confidenceTotal;
	int confidenceCount;
	for (int i=0; i<m_monitor->count; i=j)
	{
		EANYCODE_CHAR* ch = &m_monitor->text[i];
		if (currentWord==nullptr || ch->blanks>0 || (currentWord!=nullptr && (ch->left<currentWord->Left)))
		{
			if (currentWord!=nullptr && ch->left<currentWord->Left)
					lineIndex++;
			currentWord = gcnew Word();
			currentWord->CharList = gcnew List<Character ^>();
			confidenceTotal = 0;
			confidenceCount = 0;
			currentWord->LineIndex = lineIndex;
			currentWord->Blanks = ch->blanks;
			currentWord->Left = ch->left;
			currentWord->Top = ch->top;
			currentWord->Right = ch->right;
			currentWord->Bottom = ch->bottom;
			for (j = i; j < m_monitor->count; j++)
			{
				EANYCODE_CHAR* unich = &m_monitor->text[j];
				if (ch->left != unich->left || ch->right != unich->right ||	ch->top != unich->top || ch->bottom != unich->bottom)
					break;
				unistr[j - i] = static_cast<unsigned char>(unich->char_code);
				// confidenceTotal += (int)((-unich->confidence*0.035)*5.0+100);
				confidenceTotal += unich->confidence; // Every characters of a word have the same value, useless but I leave it
				confidenceCount++;
			}
			unistr[j - i] = 0;
			String^ tmp = gcnew String(unistr, 0, j-i, System::Text::Encoding::UTF8);
			currentWord->CharList->Add(gcnew Character(tmp[0], ch->left, ch->top, ch->right, ch->bottom));
			currentWord->Text = tmp;
			currentWord->Confidence = (Double)confidenceTotal / (Double)confidenceCount;
			currentWord->FontIndex = ch->font_index;
			currentWord->PointSize = ch->point_size;
			currentWord->Formating = ch->formatting;
			result->Add(currentWord);
		}
		else
		{
			if (currentWord!=nullptr)
			{
				for (j = i; j < m_monitor->count; j++)
				{
					EANYCODE_CHAR* unich = &m_monitor->text[j];
					if (ch->left != unich->left || ch->right != unich->right ||	ch->top != unich->top || ch->bottom != unich->bottom)
						break;
					unistr[j - i] = static_cast<unsigned char>(unich->char_code);
					// confidenceTotal += (int)((-unich->confidence*0.035)*5.0+100);
					confidenceTotal += unich->confidence; // Every characters of a word have the same value, useless but I leave it
					confidenceCount++;
				}
				unistr[j - i] = 0;
				String^ tmp = gcnew String(unistr, 0, j-i, System::Text::Encoding::UTF8);
				currentWord->CharList->Add(gcnew Character(tmp[0], ch->left, ch->top, ch->right, ch->bottom));
				currentWord->Text += tmp;
				currentWord->Confidence = (Double)confidenceTotal / (Double)confidenceCount;
				currentWord->Left = Math::Min(currentWord->Left, (int)ch->left);
				currentWord->Top = Math::Min(currentWord->Top, (int)ch->top);
				currentWord->Right = Math::Max(currentWord->Right, (int)ch->right);
				currentWord->Bottom = Math::Max(currentWord->Bottom, (int)ch->bottom);
			}
			else
				j++;
		}
	}
	return result;
}

int	tessnet2::Tesseract::LineCount	(List<Word ^>^ words)
{
	Dictionary<int, int>^ lines = gcnew Dictionary<int, int>();
	for each (Word^ word in words)
	{
		if (!lines->ContainsKey(word->LineIndex))
			lines->Add(word->LineIndex, 1);
	}
	return lines->Count;
}

List<tessnet2::Word ^>^ tessnet2::Tesseract::GetLineWords(List<tessnet2::Word ^>^ words, int lineIndex)
{
	List<Word ^>^ result = gcnew List<Word ^>();
	for each (Word^ word in words)
	{
		if (word->LineIndex==lineIndex)
			result->Add(word);
	}
	return result;
}

String^ tessnet2::Tesseract::GetLineText (List<tessnet2::Word ^>^ words, int lineIndex)
{
	List<Word ^>^ line = GetLineWords(words, lineIndex);
	System::Text::StringBuilder^ sb = gcnew System::Text::StringBuilder();
	String^ sep = String::Empty;
	for each (Word^ word in line)
	{
		sb->Append(sep);
		sb->Append(word->Text);
		sep = " ";
	}
	return sb->ToString();
}
