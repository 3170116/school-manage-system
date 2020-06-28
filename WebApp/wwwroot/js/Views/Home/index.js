window.onload = function () {

    //swap the tabs
    document.getElementById('logInTab').onclick = function () {

        document.getElementById('logInTab').classList = "nav-link active";
        document.getElementById('signUpTab').classList = "nav-link";

        document.getElementById('logIn-content').classList = "tab-pane fade show active";
        document.getElementById('signUp-content').classList = "tab-pane fade";
    }
    document.getElementById('signUpTab').onclick = function () {

        document.getElementById('logInTab').classList = "nav-link";
        document.getElementById('signUpTab').classList = "nav-link active";

        document.getElementById('logIn-content').classList = "tab-pane fade";
        document.getElementById('signUp-content').classList = "tab-pane fade show active";
    }

}