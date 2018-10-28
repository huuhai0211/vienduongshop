(function (app) {
    app.controller('locationListController', locationListController);

    locationListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function locationListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.locations = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getLocations = getLocations;
        $scope.keyword = '';
        $scope.search = search;

        $scope.deleteLocation = deleteLocation;

        $scope.$watch("locations", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.selectAll = selectAll;

        $scope.isAll = false;

        $scope.deleteMultiple = deleteMultiple;

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.locations, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.locations, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                params: {
                    checkedLocations: JSON.stringify(listId)
                }
            }
            apiService.del('api/location/deletemulti', config, function (result) {
                search();
            }, function (error) {

            });
        }

        function deleteLocation(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/location/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            getLocations();
        }

        function getLocations(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10,
                }
            }
            apiService.get('api/location/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }
                $scope.locationS = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load location failed.');
            });
        }

        $scope.getLocations();
    }
})(angular.module('shop.locations'));