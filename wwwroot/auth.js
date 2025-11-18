window.auth = {
    setUser: function (username) {
        document.cookie = "authUser=" + username + "; path=/; max-age=31536000"; // 1 year
    },

    getUser: function () {
        const match = document.cookie.match(/(^| )authUser=([^;]+)/);
        return match ? match[2] : "";
    },

    clearUser: function () {
        document.cookie = "authUser=; path=/; expires=Thu, 01 Jan 1970 00:00:00 GMT";
    }
};
