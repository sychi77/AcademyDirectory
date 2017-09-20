//Index Controller
(function () {
    "use strict";
    angular
        .module('academyApp')
        .controller('studentsIndexController', studentsIndexController);

    studentsIndexController.$inject = ['$scope', 'studentsService', '$window', 'toastr'];

    function studentsIndexController($scope, studentsService, $window, toastr) {

        var vm = this;
        vm.$scope = $scope;
        vm.studentsService = studentsService;
        vm.$onInit = _init;
        vm.selectAll = _selectAll;
        vm.deleteById = _deleteById;
        vm.items = [];
        vm.student = {};
        vm.$window = $window;
        vm.index;
        vm.sortType = 'id'; // set the default sort type
        vm.sortReverse = false;  // set the default sort order
        vm.toastr = toastr;
        vm.addStudent = _addStudent;

        function _init() {
            _selectAll();
            return
        }                    
        function _selectAll() {
            return vm.studentsService.getAll()
                    .then(_selectAllSuccess, _error)
        }
        function _selectAllSuccess(data) {
            console.log(data.data);
            vm.items = data.data;
            return
        }            
        function _addStudent() {
            return vm.studentsService.post(vm.student)
                .then(_addSuccess, _addError)
        }
        function _addSuccess(data) {
            $('#myModal').modal('toggle');
            toastr.success('Student Added!', 'Success!');
            vm.student = {};
            _selectAll();
        }
        function _addError(err) {
            toastr.warning('Student Not Added. Check Your Fields.', 'Error');
        }
        function _deleteById(index, id) {
            vm.index = index;
            return vm.studentsService.delete(id)
                        .then(_deleteSuccess, _deleteError)
        }
        function _deleteSuccess() {
            vm.items.splice(vm.index, 1);
            return
        }
        function _error(err) {
            return console.log(err)
        }
        
    }
})();

