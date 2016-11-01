// simpleControls.js
(function () {
  "use strict";

  angular.module("simpleControls", [])
    .directive("simpleSpinner", simpleSpinner);

  function simpleSpinner() {
    return {
      scope: {
        show: "=displayWhen"
      },
      restrict: "E",
      templateUrl: "app/directives/controls/Spinner.html"
    };
  }

})();