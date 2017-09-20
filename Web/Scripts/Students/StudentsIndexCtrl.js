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
        vm.items = [];
        vm.student = {};
        vm.$window = $window;
        vm.sortType = 'id'; // set the default sort type
        vm.sortReverse = false;  // set the default sort order
        vm.toastr = toastr;
        vm.addBtn = _addBtn;
        vm.addStudent = _addStudent;
        vm.editStudent = _editStudent;
        vm.showDelete = false;
        vm.deleteStudent = _deleteStudent;

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
        function _addBtn() {
            vm.showDelete = false;
            vm.student = {};
            $('#myModal').modal('toggle');
        }
        function _addStudent() {
            if (vm.student.Id > 0) {
                return vm.studentsService.put(vm.student)
                    .then(_updateSuccess, _updateError)
            }
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
        function _editStudent(student) {
            vm.student.Id = student.Id;
            vm.student.FirstName = student.FirstName;
            vm.student.MiddleInitial = student.MiddleInitial;
            vm.student.LastName = student.LastName;
            vm.student.DateOfBirth = student.DateOfBirth.slice(0,10);
            vm.student.ModifiedBy = student.ModifiedBy;
            vm.showDelete = true;
            $('#myModal').modal('toggle');
        }
        function _updateSuccess(data) {
            $('#myModal').modal('toggle');
            toastr.success('Student Info Updated!', 'Success!');
            vm.student = {};
            _selectAll();
        }
        function _updateError(err) {
            toastr.warning('Student Info Not Updated. Check Your Fields.', 'Error');
        }
        function _deleteStudent() {
            return vm.studentsService.delete(vm.student.Id)
                .then(_deleteSuccess, _error)
        }
        function _deleteSuccess(resp) {
            $('#myModal').modal('toggle');
            toastr.success('Delete Successful!', 'Success!');
            vm.student = {};
            _selectAll();
            return
        }
        function _error(err) {
            return console.log(err)
        }
        
    }
})();

