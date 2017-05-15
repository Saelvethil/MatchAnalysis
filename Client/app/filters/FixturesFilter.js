var FixturesFilter = function () {
    return function (fixtures, part) {
        var out = [];

        angular.forEach(fixtures, function (fixture) {
            
            if (part === undefined || part.length === 0) {
                return;
            }

            var homeTeamIndex = fixture.homeTeamName.indexOf(part) ;
            var awayTeamIndex = fixture.awayTeamName.indexOf(part);
            if (homeTeamIndex !== -1 || awayTeamIndex !== -1) {
                out.push(fixture)
            }
        })

        return out;
    };
}