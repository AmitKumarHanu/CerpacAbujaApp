$(function () {
    //original field values
    var field_values = {
        //id        :  value
        'username': 'username',
        'password': 'password',
        'cpassword': 'password',
        'firstname': 'first name',
        'lastname': 'last name',
        'email': 'email address'
    };


    //inputfocus
    $('input#username').inputfocus({ value: field_values['username'] });
    $('input#password').inputfocus({ value: field_values['password'] });
    $('input#cpassword').inputfocus({ value: field_values['cpassword'] });
    $('input#lastname').inputfocus({ value: field_values['lastname'] });
    $('input#firstname').inputfocus({ value: field_values['firstname'] });
    $('input#email').inputfocus({ value: field_values['email'] });




    //reset progress bar
    $('#progress').css('width', '0');
    $('#progress_text').html('0% Complete');

    //first_step
   
    $('#submit_first').click(function () {
        //remove classes
        $('#first_step input').removeClass('error').removeClass('valid');

        //ckeck if inputs aren't empty
        var fields = $('#first_step input[type=text], #first_step input[type=password]');
        var error = 0;
        fields.each(function () {
            var value = $(this).val();
            if (value.length < 4 || value == field_values[$(this).attr('id')]) {
                //  $(this).addClass('error');
                //$(this).effect("shake", { times:3 }, 50);

                $(this).addClass('valid');

            } else {
                $(this).addClass('valid');
            }
        });

        if (!error) {
            if ($('#password').val() != $('#cpassword').val()) {
                $('#first_step input[type=password]').each(function () {
                    //                $(this).removeClass('valid').addClass('error');
                    //              $(this).effect("shake", { times:3 }, 50);
                    $('#progress_text').html('33% Complete');
                    $('#progress').css('width', '113px');

                    //slide steps
                    $('#first_step').slideUp();
                    $('#second_step').slideDown();
                });

                //               return false;
            } else {
                //update progress bar
                $('#progress_text').html('33% Complete');
                $('#progress').css('width', '113px');

                //slide steps
                $('#first_step').slideUp();
                $('#second_step').slideDown();
            }
        } else return false;
    });


    $('#submit_second').click(function () {
        //remove classes
        $('#second_step input').removeClass('error').removeClass('valid');

        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        var fields = $('#second_step input[type=text]');
        var error = 0;
        fields.each(function () {
            var value = $(this).val();
            if (value.length < 1 || value == field_values[$(this).attr('id')] || ($(this).attr('id') == 'email' && !emailPattern.test(value))) {
              //  $(this).addClass('error');
               // $(this).effect("shake", { times: 3 }, 50);
                $(this).addClass('valid');
              //  error++;
            } else {
                $(this).addClass('valid');
            }
        });

        if (!error) {
            //update progress bar
            $('#progress_text').html('66% Complete');
            $('#progress').css('width', '226px');

            //slide steps
            $('#second_step').slideUp();
            $('#third_step').slideDown();
        } else return false;

    });


    $('#submit_third').click(function () {
        //update progress bar
        $('#progress_text').html('100% Complete');
        $('#progress').css('width', '339px');

        //prepare the fourth step
        var fields = new Array(
            $('#username').val(),
            $('#password').val(),
            $('#email').val(),
            $('#firstname').val() + ' ' + $('#lastname').val(),
            $('#age').val(),
            $('#gender').val(),
            $('#country').val()
        );
        var tr = $('#fourth_step tr');
        tr.each(function () {
            //alert( fields[$(this).index()] )
            $(this).children('td:nth-child(2)').html(fields[$(this).index()]);
        });

        //slide steps
        $('#third_step').slideUp();
        $('#fourth_step').slideDown();
    });



    $('#submit_fourth').click(function () {
        //send information to server
        alert('Data sent');
    });

    $('#submit_first_back').click(function () {
        //remove classes
        
        $('#third_step input').removeClass('error').removeClass('valid');
       

        var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
        var fields = $('#second_step input[type=text]');
        var error = 0;
        fields.each(function () {
            var value = $(this).val();
            if (value.length < 1 || value == field_values[$(this).attr('id')] || ($(this).attr('id') == 'email' && !emailPattern.test(value))) {
                //  $(this).addClass('error');
                // $(this).effect("shake", { times: 3 }, 50);
                $(this).addClass('valid');
                //  error++;
            } else {
                $(this).addClass('valid');
            }
        });

        if (!error) {
            //update progress bar
          //  $('#progress_text').html('66% Complete');
            $('#progress').css('width', '10px');

            //slide steps
            $('#third_step').slideUp();
            $('#second_step').slideDown();
        } else return false;

    });


    $('#submit_on_first').click(function () {
    //remove classes 
    $('#second_step input').removeClass('error').removeClass('valid');
    //alert('Data sent');
    var emailPattern = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
    var fields = $('#second_step input[type=text]');
    var error = 0;
    fields.each(function () {

    var value =$(this).val();
    if (value.length < 1 || value == field_values[$(this).attr('id')] || ($(this).attr('id') == 'email' && !emailPattern.test(value))) {
        //  $(this).addClass('error');
        // $(this).effect("shake", { times: 3 }, 50);
        $(this).addClass('valid');
        //  error++;
    } else {
        $(this).addClass('valid');
    }
});

if (!error) {
    //update progress bar
    //  $('#progress_text').html('66% Complete');
    $('#progress').css('width', '10px');

    //slide steps
    $('#second_step').slideUp();
    $('#first_step').slideDown();
} else return false;

});

$('#submit_third_back').click(function () {
    //update progress bar
    //$('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');  

    //slide steps
    $('#fourth_step').slideUp();
    $('#third_step').slideDown();
});
$('#submit_fourth_back').click(function () {
    
    $('#progress').css('width', '339px');
    
    //slide steps
    $('#fifth_step').slideUp();
    $('#fourth_step').slideDown();
});

$('#fifth_step_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#sixth_step').slideUp();
    $('#fifth_step').slideDown();
});

$('#sixth_step_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#seventh_step').slideUp();
    $('#sixth_step').slideDown();
});

$('#fifth_step_nxt').click(function () {
    //update progress bar
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //prepare the fourth step
    var fields = new Array(
            $('#username').val(),
            $('#password').val(),
            $('#email').val(),
            $('#firstname').val() + ' ' + $('#lastname').val(),
            $('#age').val(),
            $('#gender').val(),
            $('#country').val()
        );
    var tr = $('#fourth_step tr');
    tr.each(function () {
        //alert( fields[$(this).index()] )
        $(this).children('td:nth-child(2)').html(fields[$(this).index()]);
    });

    //slide steps
    $('#fourth_step').slideUp();
    $('#fifth_step').slideDown();
});
$('#sixth_step_nxt').click(function () {
    //update progress bar
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //prepare the fourth step
    var fields = new Array(
            $('#username').val(),
            $('#password').val(),
            $('#email').val(),
            $('#firstname').val() + ' ' + $('#lastname').val(),
            $('#age').val(),
            $('#gender').val(),
            $('#country').val()
        );
    var tr = $('#fourth_step tr');
    tr.each(function () {
        //alert( fields[$(this).index()] )
        $(this).children('td:nth-child(2)').html(fields[$(this).index()]);
    });

    //slide steps
    $('#fifth_step').slideUp();
    $('#sixth_step').slideDown();
});

$('#seventh_step_nxt').click(function () {    
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');   

    //slide steps
    $('#sixth_step').slideUp();
    $('#seventh_step').slideDown();
});

$('#second_step_nxt').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#divpersonaldetails2').slideUp();
    $('#divpassport').slideDown();
});

$('#contact_nxt').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#divpassport').slideUp();
    $('#divcontact').slideDown();
});

$('#passport_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divcontact').slideUp();
    $('#divpassport').slideDown();
});

$('#first_step_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divpersonaldetails2').slideUp();
    $('#first_step').slideDown();
});

$('#visa1_nxt').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#divcontact').slideUp();
    $('#divvisa1').slideDown();
});

$('#visa1_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divvisa2').slideUp();
    $('#divvisa1').slideDown();
});

$('#next_second_step').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#divvisa2').slideUp();
    $('#second_step').slideDown();
});

$('#visa2_nxt').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#divvisa1').slideUp();
    $('#divvisa2').slideDown();
});

$('#contact_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divvisa1').slideUp();
    $('#divcontact').slideDown();
});

$('#visa2_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#second_step').slideUp();
    $('#divvisa2').slideDown();
});

$('#contact_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divvisa1').slideUp();
    $('#divcontact').slideDown();
});

$('#personaldetails2_nxt').click(function () {
    //update progress bar   
    $('#progress_text').html('100% Complete');
    $('#progress').css('width', '339px');

    //slide steps
    $('#first_step').slideUp();
    $('#divpersonaldetails2').slideDown();
});

$('#personaldetails2_back').click(function () {

    $('#progress').css('width', '339px');

    //slide steps
    $('#divpassport').slideUp();
    $('#divpersonaldetails2').slideDown();
});



});

