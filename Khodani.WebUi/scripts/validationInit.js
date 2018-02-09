function formValidation() {
    "use strict";

    
    $('#DirectorOne').validate({
        rules: {
            DirectorOneName: {
                required: true
            },
            DirectorOneSurname: {
                required: true
            },
            DirectorOneCell: {
                required: true,
                digits: true,
                minlength:10
            },
            DirectorOneEmail: {
                required: true,
                email:true
            },
            DirectorOneIDNumber: {
                required: true,
                digits: true,
                minlength: 13
            },
            DirectorOnePhysicalAddress: {
                required: true
            },
            DirectorOnePostalAddress: {
                required: true
            },
            fileuploadOneID: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

    $('#DirectorTwo').validate({
        rules: {
            DirectorTwoName: {
                required: true
            },
            DirectorTwoSurname: {
                required: true
            },
            DirectorTwoCell: {
                required: true,
                digits: true,
                minlength: 10
            },
            DirectorTwoEmail: {
                required: true,
                email: true
            },
            DirectorTwoIDNumber: {
                required: true,
                digits: true,
                minlength: 13
            },
            DirectorTwoPhysicalAddress: {
                required: true
            },
            DirectorTwoPostalAddress: {
                required: true
            },
            fileuploadTwoID: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

    $('#DirectorThree').validate({
        rules: {
            DirectorThreeName: {
                required: true
            },
            DirectorThreeSurname: {
                required: true
            },
            DirectorThreeCell: {
                required: true,
                digits: true,
                minlength: 10
            },
            DirectorThreeEmail: {
                required: true,
                email: true
            },
            DirectorThreeIDNumber: {
                required: true,
                digits: true,
                minlength: 13
            },
            DirectorThreePhysicalAddress: {
                required: true
            },
            DirectorThreePostalAddress: {
                required: true
            },
            fileuploadThreeID: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

    $('#DirectorFour').validate({
        rules: {
            DirectorFourName: {
                required: true
            },
            DirectorFourSurname: {
                required: true
            },
            DirectorFourCell: {
                required: true,
                digits: true,
                minlength: 10
            },
            DirectorFourEmail: {
                required: true,
                email: true
            },
            DirectorFourIDNumber: {
                required: true,
                digits: true,
                minlength: 13
            },
            DirectorFourPhysicalAddress: {
                required: true
            },
            DirectorFourPostalAddress: {
                required: true
            },
            fileuploadFourID: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });


    $('#DirectorFive').validate({
        rules: {
            DirectorFiveName: {
                required: true
            },
            DirectorFiveSurname: {
                required: true
            },
            DirectorFiveCell: {
                required: true,
                digits: true,
                minlength: 10
            },
            DirectorFiveEmail: {
                required: true,
                email: true
            },
            DirectorFiveIDNumber: {
                required: true,
                digits: true,
                minlength: 13
            },
            DirectorFivePhysicalAddress: {
                required: true
            },
            DirectorFivePostalAddress: {
                required: true
            },
            fileuploadFiveID: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

    $('#CompnayDetails').validate({
        rules: {
            CompanyName: {
                required: true
            },
            CompanyEmail: {
                required: true,
                email:true
            },
            URL: {
                required: true,
              url:true
            },
            CompanyPhysicalAddress: {
                required: true
            },
            CompanyPostalAddress: {
                required: true
            }
        },
        errorClass: 'help-block col-sm-12',
        errorElement: 'span',
        highlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-success').addClass('has-error');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents('.form-group').removeClass('has-error').addClass('has-success');
        }
    });

  

}