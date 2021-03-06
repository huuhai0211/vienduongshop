﻿(function (app) {
    app.controller('contributorListController', contributorListController);

    contributorListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function contributorListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.contributor = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getContributor = getContributor;
        $scope.keyword = '';
        $scope.search = search;
        $scope.deleteContributor = deleteContributor;

        $scope.$watch("contributor", function (n, o) {
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
                angular.forEach($scope.contributor, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.contributor, function (item) {
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
                    checkedContributor: JSON.stringify(listId)
                }
            }
            apiService.del('api/contributor/deletemulti', config, function (result) {
                search();
            }, function (error) {

            });
        }

        function deleteContributor(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/contributor/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function search() {
            getContributor();
        }

        function getContributor(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10,
                }
            }
            apiService.get('api/contributor/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
                }
                $scope.contributor = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load contributor failed.');
            });
        }

        $scope.getContributor();
    }
})(angular.module('shop.contributor'));