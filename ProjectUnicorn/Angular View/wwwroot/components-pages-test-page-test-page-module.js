(window["webpackJsonp"] = window["webpackJsonp"] || []).push([["components-pages-test-page-test-page-module"],{

/***/ "./src/app/components/pages/test-page/test-page.module.ts":
/*!****************************************************************!*\
  !*** ./src/app/components/pages/test-page/test-page.module.ts ***!
  \****************************************************************/
/*! exports provided: TestPageModule */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TestPageModule", function() { return TestPageModule; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
/* harmony import */ var _angular_common__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! @angular/common */ "./node_modules/@angular/common/fesm5/common.js");
/* harmony import */ var _angular_router__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! @angular/router */ "./node_modules/@angular/router/fesm5/router.js");
/* harmony import */ var _test_page_test_page_component__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./test-page/test-page.component */ "./src/app/components/pages/test-page/test-page/test-page.component.ts");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};




var TestPageModule = /** @class */ (function () {
    function TestPageModule() {
    }
    TestPageModule = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["NgModule"])({
            imports: [
                _angular_common__WEBPACK_IMPORTED_MODULE_1__["CommonModule"],
                _angular_router__WEBPACK_IMPORTED_MODULE_2__["RouterModule"].forChild([
                    { path: '', redirectTo: 'page', pathMatch: 'full' },
                    { path: 'page', component: _test_page_test_page_component__WEBPACK_IMPORTED_MODULE_3__["TestPageComponent"] }
                ])
            ],
            declarations: [_test_page_test_page_component__WEBPACK_IMPORTED_MODULE_3__["TestPageComponent"]]
        })
    ], TestPageModule);
    return TestPageModule;
}());



/***/ }),

/***/ "./src/app/components/pages/test-page/test-page/test-page.component.css":
/*!******************************************************************************!*\
  !*** ./src/app/components/pages/test-page/test-page/test-page.component.css ***!
  \******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = ""

/***/ }),

/***/ "./src/app/components/pages/test-page/test-page/test-page.component.html":
/*!*******************************************************************************!*\
  !*** ./src/app/components/pages/test-page/test-page/test-page.component.html ***!
  \*******************************************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

module.exports = "<p>\n  test-page works!\n</p>\n"

/***/ }),

/***/ "./src/app/components/pages/test-page/test-page/test-page.component.ts":
/*!*****************************************************************************!*\
  !*** ./src/app/components/pages/test-page/test-page/test-page.component.ts ***!
  \*****************************************************************************/
/*! exports provided: TestPageComponent */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "TestPageComponent", function() { return TestPageComponent; });
/* harmony import */ var _angular_core__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! @angular/core */ "./node_modules/@angular/core/fesm5/core.js");
var __decorate = (undefined && undefined.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (undefined && undefined.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};

var TestPageComponent = /** @class */ (function () {
    function TestPageComponent() {
    }
    TestPageComponent.prototype.ngOnInit = function () {
    };
    TestPageComponent = __decorate([
        Object(_angular_core__WEBPACK_IMPORTED_MODULE_0__["Component"])({
            selector: 'app-test-page',
            template: __webpack_require__(/*! ./test-page.component.html */ "./src/app/components/pages/test-page/test-page/test-page.component.html"),
            styles: [__webpack_require__(/*! ./test-page.component.css */ "./src/app/components/pages/test-page/test-page/test-page.component.css")]
        }),
        __metadata("design:paramtypes", [])
    ], TestPageComponent);
    return TestPageComponent;
}());



/***/ })

}]);
//# sourceMappingURL=components-pages-test-page-test-page-module.js.map