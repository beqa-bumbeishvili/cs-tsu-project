function validations(form) {
    var letters = /^[A-Za-z]+$/;
    var numbers = /^[-+]?[0-9]+$/;
    var passw = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$/;

    if (form.firstname.value.length == 0 || !form.firstname.value.match(letters) || form.firstname.value.length < 2 || form.firstname.value.length > 25) {
        alert("firstname should contain only letters in range 2-25");
        return false;
    }

    if (form.lastname.value.length == 0 || !form.lastname.value.match(letters) || form.lastname.value.length < 4 || form.lastname.value.length > 30) {
        alert("lastname should contain only letters in range 4-30");
        return false;
    }

    if (form.username.value.length == 0 || form.username.value.length < 4 || form.username.value.length > 20) {
        alert("username should contain only letters in range 4-20");
        return false;
    }

    if (form.email.value.length == 0 || /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(form.email.value) || form.email.value.length < 6 || form.email.value.length > 40) {
        alert("please type valid email");
        return false;
    }

    if (form.pass.value.length == 0 || !form.pass.value.match(passw) || form.pass.value.length < 6 || form.pass.value.length > 40) {
        alert("please type valid password");
        return false;
    }
    
    if (!form.repeatPass.value == form.pass.value)  {
        alert("password should match previous one");
        return false;
    }


}