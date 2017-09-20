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

        function _put(data, id) {
            var settings = {
                url: "/api/students/" + id
                , method: "PUT"
                , cache: false
                , headers: { 'Content-Type': "application/json; charset=UTF-8" }
                , data: JSON.stringify(data)
                , withCredentials: true

            };
            return $http(settings)
                .then(_complete, _fail);
        }

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
        function _complete(data) {
            return data;
        }
        function _fail(err) {
            return $q.reject(err);
        }
    }
})();