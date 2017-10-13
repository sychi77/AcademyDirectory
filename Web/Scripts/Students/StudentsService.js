//Students Service
(function () {
    "use strict";
    angular
        .module('academyApp')
        .service('studentsService', studentsService);
    studentsService.$inject = ['$http', '$q'];

    function studentsService($http, $q) {
        return {
            getAll: _getAll,
            delete: _delete,
            post: _post,
            put: _put,
            getById: _getById
        };
        //GET call for all students info
        function _getAll() {
            var settings = {
                url: "/api/students",
                method: 'GET',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //DELETE student based on ID
        function _delete(id) {
            var settings = {
                url: "/api/students/" + id,
                method: 'DELETE',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //POST call to add new student
        function _post(myData) {
            var settings = {
                url: "/api/students"
                , method: "POST"
                , cache: false
                , headers: { 'Content-Type': "application/json; charset=UTF-8" }
                , data: JSON.stringify(myData)
                , withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //PUT call to update existing student
        function _put(data) {
            var settings = {
                url: "/api/students/"
                , method: "PUT"
                , cache: false
                , headers: { 'Content-Type': "application/json; charset=UTF-8" }
                , data: JSON.stringify(data)
                , withCredentials: true

            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //GET call one student based on ID
        function _getById(id) {
            var settings = {
                url: "/api/students/" + id,
                method: 'GET',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
                .then(_complete, _fail);
        }
        //Promised functions returning successful data or error
        function _complete(data) {
            return data;
        }
        function _fail(err) {
            return $q.reject(err);
        }
    }
})();