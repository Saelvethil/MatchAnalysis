var UsersFilter = function () {
    return function (users, part) {
        var out = [];

        if (part === undefined || part.length === 0) {
            return users;
        }

        angular.forEach(users, function (user) {
            var usernameIndex = user.UserName.indexOf(part);           
            if (usernameIndex !== -1) {
                out.push(user)
            }
        })

        return out;
    };
}