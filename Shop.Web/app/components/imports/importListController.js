﻿(function (app) {
    app.controller('importListController', importListController);

    importListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function importListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.imports = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        //$scope.getProductCategories = getProductCategories;
        //$scope.keyword = '';
        //$scope.search = search;

        //$scope.deleteProductCategory = deleteProductCategory;

        //$scope.$watch("productCategories", function (n, o) {
        //    var checked = $filter("filter")(n, { checked: true });
        //    if (checked.length) {
        //        $scope.selected = checked;
        //        $('#btnDelete').removeAttr('disabled');
        //    } else {
        //        $('#btnDelete').attr('disabled', 'disabled');
        //    }
        //}, true);

        //$scope.selectAll = selectAll;

        //$scope.isAll = false;

        //$scope.deleteMultiple = deleteMultiple;

        //function selectAll() {
        //    if ($scope.isAll === false) {
        //        angular.forEach($scope.productCategories, function (item) {
        //            item.checked = true;
        //        });
        //        $scope.isAll = true;
        //    } else {
        //        angular.forEach($scope.productCategories, function (item) {
        //            item.checked = false;
        //        });
        //        $scope.isAll = false;
        //    }
        //}

        //function deleteMultiple() {
        //    var listId = [];
        //    $.each($scope.selected, function (i, item) {
        //        listId.push(item.ID);
        //    });
        //    var config = {
        //        params: {
        //            checkedProductCategories: JSON.stringify(listId)
        //        }
        //    }
        //    apiService.del('api/productcategory/deletemulti', config, function (result) {
        //        search();
        //    }, function (error) {

        //    });
        //}

        //function deleteProductCategory(id) {
        //    $ngBootbox.confirm('Bạn có chắc muốn xóa').then(function () {
        //        var config = {
        //            params: {
        //                id: id
        //            }
        //        }
        //        apiService.del('api/productcategory/delete', config, function () {
        //            notificationService.displaySuccess('Xóa thành công');
        //            search();
        //        }, function () {
        //            notificationService.displayError('Xóa không thành công');
        //        })
        //    });
        //}

        //function search() {
        //    getProductCategories();
        //}

        //function getProductCategories(page) {
        //    page = page || 0;
        //    var config = {
        //        params: {
        //            keyword: $scope.keyword,
        //            page: page,
        //            pageSize: 10,
        //        }
        //    }
        //    apiService.get('api/productcategory/getall', config, function (result) {
        //        if (result.data.TotalCount == 0) {
        //            notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
        //        }
        //        else {
        //            notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi');
        //        }
        //        $scope.productCategories = result.data.Items;
        //        $scope.page = result.data.Page;
        //        $scope.pagesCount = result.data.TotalPages;
        //        $scope.totalCount = result.data.TotalCount;
        //    }, function () {
        //        console.log('Load product category failed.');
        //    });
        //}

        //$scope.getProductCategories();
    }
})(angular.module('shop.imports'));