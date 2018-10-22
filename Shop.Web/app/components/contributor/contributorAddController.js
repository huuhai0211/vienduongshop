
(function (app) {
    app.controller('contributorAddController', contributorAddController);

    contributorAddController.$inject = ['apiService', '$scope', '$state', 'commonService', 'notificationService'];

    function contributorAddController(apiService, $scope, $state, commonService, notificationService) {
        $scope.contributor = {
            Status: true
        }
        $scope.AddContributor = AddContributor;

        function AddContributor() {
            apiService.post('api/contributor/create', $scope.contributor,
                function (result) {
                    $state.go('contributors');
                }, function (error) {
                    console.log('Thêm mới không thành công');
                });

        }

        $scope.GetSeoTitle = GetSeoTitle;

      
        function GetSeoTitle() {
            $scope.contributor.Alias = commonService.getSeoTitle($scope.contributor.Name);
        }
    }
})(angular.module('shop.contributor'));
// ơ nó đâu? bạn có làm gì vào đâu