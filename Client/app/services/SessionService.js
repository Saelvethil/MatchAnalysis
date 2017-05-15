var SessionService = function ($cookies) {
    
    this.token = undefined;
    this.getToken = function () {
        if (!$cookies.apiAuthToken) {
            if (!this.token) {
                return undefined;
            }
            this.setToken(this.token);
        }
        return $cookies.apiAuthToken;
    }
    this.setToken = function (token) {
        this.token = token;
        $cookies.apiAuthToken = token;
    }
    
    this.role = undefined;
    this.getRole = function () {
        if (!$cookies.userRole) {
            if (!this.role) {
                return undefined;
            }
            this.setRole(this.role);
        }
        return $cookies.userRole;
    }
    this.setRole = function (role) {
        this.role = role;
        $cookies.userRole = role;
    }

    this.clearValues = function () {
        console.log("ClearValues");
        this.setToken(undefined);
        this.setRole(undefined);
    }

    this.loggedIn = false;
    this.isAdmin = false;
    this.isModerator = false;

    this.isLoggedInEval = function () {
        var actualToken = this.getToken();
        var result = false;

        if (actualToken !== undefined) {
            //workaround for - sometimes undefined is undefined, sometimes its string "undefined", real token has length = 514
            result = actualToken.length > 9;
        }

        return result;
    }

    this.isAdminEval = function () {
        return this.getRole() === '"Admin"';
    }

    this.isModeratorEval = function () {
        return this.getRole() === '"Moderator"' || this.getRole() === '"Admin"';
    }

    this.updateModel = function () {
        this.isLoggedIn = this.isLoggedInEval();
        this.isAdmin = this.isAdminEval();
        this.isModerator = this.isModeratorEval();
    }

    this.apiUrl = 'http://localhost:11070';
}

SessionService.$inject = ['$cookies'];