window.onload = function () {

    //handle maname menu item
    function hideManageMenuItem() {
        if (window.innerWidth < 990) {
            document.getElementById('hidden-nav-item').classList = 'nav-item';
            document.getElementById('show-up-nav-item').classList = 'nav-item hidden';
        } else {
            document.getElementById('hidden-nav-item').classList = 'nav-item hidden';
            document.getElementById('show-up-nav-item').classList = 'nav-item';
        }
    }

    window.onresize = hideManageMenuItem;
    //refresh the menu when page loads
    hideManageMenuItem();

}