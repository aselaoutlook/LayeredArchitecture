var app = angular.module("ContactApp", []);
app.controller("ContactController", function ($scope, $http) {

    $scope.Contact = {
        "ContactId": "",
        "Name": "",
        "Address": "",
        "City": "",
        "Country": ""
    };

    $scope.submit = function () {
        if ($scope.Contact.Name) {

            if ($scope.Contact.ContactId == '') {
                $scope.Add();
            } else {
                $scope.Update();
            }
        }
    };

    $scope.Add = function () {
        var contact = {
            "Name": $scope.Contact.Name,
            "Address": $scope.Contact.Address,
            "City": $scope.Contact.City,
            "Country": $scope.Contact.Country
        }

        $http.post('http://localhost:24839/api/contactapi', contact)
            .then(function (response) {
                $scope.Reset();
                $scope.LoadContacts();
                alert('Contact Added Successfully');
            }, function (error) {
                alert("error");
            });
    }

    $scope.Update = function () {
        var contact = {
            "ContactId": $scope.Contact.ContactId,
            "Name": $scope.Contact.Name,
            "Address": $scope.Contact.Address,
            "City": $scope.Contact.City,
            "Country": $scope.Contact.Country
        }
        
        $http({
            method: "PUT", data: contact, url: "http://localhost:24839/api/contactapi" 
        }).then(function (response) {
                $scope.Reset();
                $scope.LoadContacts();
                alert('Contact Updated Successfully');
            }, function (error) {
                alert("error");
            });
    }

    $scope.LoadContacts = function () {
        $http.get('http://localhost:24839/api/contactapi')
            .then(function (response) {
                $scope.contacts = response.data;
            }, function (error) {
                alert("error");
            });
    }

    $scope.LoadContactById = function (contactId) {
        $http({
            method: "GET", url: "http://localhost:24839/api/contactapi?contactId=" + contactId
        }).then(function successCallback(data, status, headers, config) {
            $scope.Contact = data.data;
        }, function errorCallback(response) {
            alert("error");
        });
    }

    $scope.DeleteContact = function (contactId) {
        $http({
            method: "DELETE", url: "http://localhost:24839/api/contactapi?contactId=" + contactId
        }).then(function successCallback(data, status, headers, config) {
            $scope.LoadContacts();
            alert('Contact Deleted Successfully');
        }, function errorCallback(response) {
            alert("error");
        });
    }

    $scope.Reset = function () {
        $scope.formcontact.$setPristine();
        $scope.formcontact.$setUntouched();
        $scope.Contact.ContactId = "";
        $scope.Contact.Name = "";
        $scope.Contact.Address = "";
        $scope.Contact.City = "";
        $scope.Contact.Country = "";
    }

    $scope.LoadContacts();
});