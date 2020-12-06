app.controller('IndexController', function ($scope, $http) {

    $http.get('/api/Index').success(function (data) {

        // Get Top news Near to Slider
        $scope.First = data.IsMain[2]
        $scope.Second = data.IsMain[0]
        $scope.Third = data.IsMain[1]
       

        // Get Lastest Video and Popular
        $scope.LastestNews = data.lstNews.slice(0, 4);     
        $scope.PopularNews = data.lstNews.slice(4, 8);


        $scope.ListVideos = data.lstVideos;

    });

    $scope.mySplit = function (string, nb) {
        var array = string.split('T');
        return array[nb];
    }
});

