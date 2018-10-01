
(function (app) {
    app.controller('contributorAddController', contributorAddController);

    contributorAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function contributorAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.contributor = {
            Status: true
        }
        $scope.AddContributor = AddContributor;

        function AddContributor() {
         //   $scope.contributor.MoreImage = JSON.stringify($scope.moreImages);
            apiService.post('api/contributor/create', $scope.contributor,
                function (result) {
                    $state.go('contributor');
                }, function (error) {
                    console.log('Thêm mới không thành công');
                });

        }

        //$scope.GetSeoTitle = GetSeoTitle;

        //$scope.ckeditorOptions = {
        //    language: 'vi',
        //    height: '200px'
        //}
        //function GetSeoTitle() {
        //    $scope.contributor.Alias = commonService.getSeoTitle($scope.contributor.Name);
        //}

       //
       
        //$scope.ChooseImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.contributor.Image = fileUrl;
        //        })
        //    }
        //    finder.popup();
        //}
        //loadProductCategories();

        //$scope.moreImages = [];
        //$scope.ChooseMoreImage = function () {
        //    var finder = new CKFinder();
        //    finder.selectActionFunction = function (fileUrl) {
        //        $scope.$apply(function () {
        //            $scope.moreImages.push(fileUrl);
        //        })
        //    }
        //    finder.popup();
        //}
    }
})(angular.module('shop.contributors'));