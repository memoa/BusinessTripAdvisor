
const UI = (function () {
    const toSignUpForm = () => {
        document.querySelector("#sign-up-div").style.display = "block";
        document.querySelector("#log-in-div").style.display = "none";
        document.querySelector("title").textContent = "BTA | Sign up"
    }

    const toLogInForm = () => {
        document.querySelector("#log-in-div").style.display = "block";
        document.querySelector("#sign-up-div").style.display = "none";
        document.querySelector("title").textContent = "BTA | Log in"
    }

    document.querySelector("#btn-to-sign-up").addEventListener("click", toSignUpForm);
    document.querySelector("#btn-to-log-in").addEventListener("click", toLogInForm);

}) ();

/*
const UI = (function () {
    const toSignUpForm = () => {
        $("#sign-up-div").style.display = "block";
        $("#log-in-div").style.display = "none";
        $("title").textContent = "BTA | Sign up"
    }

    const toLogInForm = () => {
        $("#log-in-div").style.display = "block";
        $("#sign-up-div").style.display = "none";
        $("title").textContent = "BTA | Log in"
    }

   $("#btn-to-sign-up").on("click", toSignUpForm);
   $("#btn-to-log-in").on("click", toLogInForm);
}) ();
*/
