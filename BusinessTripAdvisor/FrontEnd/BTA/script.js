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

