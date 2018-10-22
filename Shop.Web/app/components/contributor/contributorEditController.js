
(function (app) {
    app.controller('contributorEditController', contributorEditController);

    contributorEditController.$inject = ['apiService', '$scope', '$state', '$stateParams', 'commonService'];

    function contributorEditController(apiService, $scope, $state, $stateParams, commonService) {
        $scope.contributor = {

        }

        $scope.UpdateContributor = UpdateContributor;

        function loadContributorDetail() {
            apiService.get('api/contributor/getbyid/' + $stateParams.id, null, function (result) {
                $scope.contributor = result.data;
            }, function (error) {

            });
        }

        function UpdateContributor() {
            apiService.put('api/contributor/update', $scope.contributor, function (result) {
                $state.go('contributors');
            }, function (error) {
                console.log('Cập nhật không thành công');
            });
        }
        loadContributorDetail();
    }
})(angular.module('shop.contributor'));