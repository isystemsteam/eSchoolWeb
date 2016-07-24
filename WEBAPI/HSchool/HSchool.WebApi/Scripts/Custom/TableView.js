
$.fn.GridView = function (options) {    
    var settings = $.extend({
        data: null,
        templateName: null,
        url: "applicationSearch",
        pageSize: 10,
        pageIndex: 1,
        postData: null,
        dataType: null,
        isLocalData: false,
    }, options);

    return this.each(function () {        
        var _component = $(this);
        //to bind template
        var _bindTemplate = function (data) {            
            try {
                var template = $.templates("#" + settings.templateName);
                var htmlOutput = template.render(data);
                //alert(htmlOutput);
                _component.html(htmlOutput);
            } catch (e) {
                console.log(e);
                $(this).html("Not valid data format");
            }
        };

        //to bind error on the controls
        var _errorBind = function (xhr, message, error) {
            alert(xhr.statusText + message + error)
            _component.html(xhr.message);
            return this;
        };

        if (!settings.isLocalData) {
            //ajax call to get values            
            $.ajax({
                url: settings.url,
                data: settings.postData,
                type: 'POST',
                dataType: settings.dataType,
                success: _bindTemplate,
                error: _errorBind
            });
        } else {
            _bindTemplate(settings.data);
        }
    });
};


//var TableView1 = function (params) {
//    this.uri = params["uri"] != null ? params["uri"] : '',
//    this.tableCtrl = params["tableCtrl"] != null ? params["tableCtrl"] : '';
//    this.pageCtrl = params["pageCtrl"] != null ? params["pageCtrl"] : '';
//    this.pageSize = params["pageSize"] != null ? params["pageSize"] : 20;
//    this.pageIndex = params["pageIndex"] != null ? params["pageIndex"] : 1;
//    this.rowList = params["rowList"] != null ? params["rowList"] : [5, 10, 20, 50];
//    this.dataType = params["dataType"] != null ? params["dataType"] : 'json';
//    this.loadOnce = params["loadOnce"] != null ? params["loadOnce"] : false;
//    this.sorting = params["sorting"] != null ? params["sorting"] : false;
//    this.jsonObject = params["jsonObject"] != null ? params["jsonObject"] : {};
//    this.columns = params["columns"] != null ? params["columns"] : [];
//    this.localData = params["gridData"] != null ? params["gridData"] : null;
//    this.rowSelect = params["gridData"] != null ? params["gridData"] : null;
//    this.totalRows = params["totalRows"] != null ? params["totalRows"] : null;
//    this.loadComplete = params["loadComplete"] != null ? params["loadComplete"] : null;
//    this.totalPages = 0;
//    this.init = function () {
//        try {
//            //load once
//            if (this.loadOnce) {
//                if (this.localData != null) {
//                    _bindLocalGrid(this.localData, this);
//                } else {
//                    $("#" + this.tableCtrl).html("<h1 class=''>No Data Available<h1>");
//                    $("#" + this.pageCtrl).html("");
//                }
//            } else {
//                //load data from server call
//                _loadData(this);
//            }
//        } catch (e) {
//            console.log(e);
//        }
//    };

//    //to refresh the grid
//    var _reloadGrid = function (component) {
//        if (component.loadOnce) {
//            _bindLocalGrid(component.localData, component);
//        } else {
//            _loadData(component);
//        }
//    };

//    //to bind local data grid
//    var _bindLocalGrid = function (data, component) {
//        //start table bind
//        var columns = data.columns;
//        var tables = "<table width='100%' class='standard'>";
//        //to add table head
//        tables += "<tr>";
//        for (var c = 0; c < columns.length; c++) {
//            tables += "<th>" + columns[c] + "</th>";
//        }
//        tables += "</tr>";
//        var startRow = (component.pageIndex - 1) * component.pageSize;
//        var endRow = parseInt(startRow) + parseInt(component.pageSize);
//        endRow = endRow > data.totalRows ? data.totalRows : endRow;

//        if (data.rows != null && data.rows.length > 0) {
//            //to add table body
//            for (var d = startRow; d < endRow; d++) {
//                tables += "<tr>";
//                for (var cs = 0; cs < columns.length; cs++) {
//                    tables += "<td>" + data.rows[d].cell[cs] + "</td>";
//                }
//                tables += "</tr>";
//            }
//        } else {
//            tables += "<tr><td colspan='" + columns.length + "'>No results found </td></tr>";
//        }
//        tables += "</table>";
//        $("#" + component.tableCtrl).html(tables);
//        component.totalRows = data.totalRows;
//        component.totalPages = Math.ceil(component.totalRows / component.pageSize);
//        _pager.init(component);
//    };

//    //bind the component
//    var _bindGrid = function (data, component) {
//        //start table bind
//        var columns = data.columns;
//        var tables = "<table width='100%' class='standard'>";
//        //to add table head
//        tables += "<tr>";
//        for (var c = 0; c < columns.length; c++) {
//            tables += "<th>" + columns[c] + "</th>";
//        }
//        tables += "</tr>";

//        if (data.rows != null && data.rows.length > 0) {
//            //to add table body
//            for (var d = 0; d < data.rows.length; d++) {
//                tables += "<tr>";
//                for (var cs = 0; cs < columns.length; cs++) {
//                    tables += "<td>" + data.rows[d].cell[cs] + "</td>";
//                }
//                tables += "</tr>";
//            }
//        } else {
//            tables += "<tr><td colspan='" + columns.length + "'>No results found </td></tr>";
//        }
//        tables += "</table>";
//        $("#" + component.tableCtrl).html(tables);
//        component.totalRows = data.totalRows;
//        component.totalPages = data.total;
//        _pager.init(component);
//        if (component.loadComplete != null) {
//            component.loadComplete(data);
//        }

//    };

//    var _clearGrid = function (component) {
//        $("#" + component.tableCtrl).html('No Results Found');
//        $("#" + component.pageCtrl).html('');
//    };

//    //to load data - begin
//    var _loadData = function (component) {
//        //to successcallback - begin
//        var successCallback = function (result) {
//            if (result != null && result.rows != null && result.rows != '') {
//                _bindGrid(result, component);
//            } else {
//                _clearGrid(component);
//            }
//        }
//        //to successcallback - end

//        var startRow = component.pageIndex * component.pageSize;
//        var endRow = component.pageSize + startRow;

//        var parameters = [];
//        parameters.push(new ajaxParameter("page", component.pageIndex));
//        parameters.push(new ajaxParameter("rows", component.pageSize));
//        parameters.push(new ajaxParameter("search", ''));
//        parameters.push(new ajaxParameter("sidx", ''));
//        parameters.push(new ajaxParameter("sord", ''));

//        for (var property in component.jsonObject) {
//            if (component.jsonObject.hasOwnProperty(property)) {
//                parameters.push(new ajaxParameter(property, component.jsonObject[property]));
//            }
//        }

//        jQuery.fn.OnviaCommon.ajax.get(component.uri, parameters, component.dataType, successCallback, component.handleAjaxException);
//    }
//    //to load data - end

//    var _pager = {
//        init: function (component) {
//            //to first page
//            _firstPage = function () {
//                component.pageIndex = 1;
//                _reloadGrid(component);
//            };

//            //to go next page
//            _nextPage = function () {
//                component.pageIndex = component.pageIndex + 1 < component.totalPages ? component.pageIndex + 1 : component.totalPages;
//                _reloadGrid(component);
//            };

//            //to move previous page
//            _previousPage = function () {
//                component.pageIndex = component.pageIndex - 1 > 0 ? component.pageIndex - 1 : 1;
//                _reloadGrid(component);
//            };

//            //to move last page
//            _lastPage = function () {
//                component.pageIndex = component.totalPages;
//                _reloadGrid(component);
//            }

//            //to change page index
//            _pageSizeChange = function (obj) {
//                component.pageSize = $(obj).val();
//                component.pageIndex = 1;
//                _reloadGrid(component);
//            }


//            var _pageDiv = "";
//            _pageDiv += "<div class='tblPages'>";
//            _pageDiv += "<table width='100%'>";
//            _pageDiv += "<tr>";
//            _pageDiv += "<td style='direction:ltr' width='50%' class='tablePagersItem'>";
//            _pageDiv += "<span id='gridFirstPage' onclick='_firstPage(this)' title='First Page' class=''><i class='fa fa-step-backward' aria-hidden='true'></i></span>";
//            _pageDiv += "<span id='gridPreviousPage' onclick='_previousPage(this)' title='Previous Page'><i class='fa fa-backward' aria-hidden='true'></i></span>";
//            _pageDiv += "<span>Page <input type='text' value='" + component.pageIndex + "' id='txtPageValue' class='integerField' style='width:32px'/> of " + component.totalPages + "</span>";
//            _pageDiv += "<span title='Select Page Size'><select id='selectPageSize' onChange='_pageSizeChange(this)'>";
//            for (var d = 0; d < component.rowList.length; d++) {
//                if (component.pageSize == component.rowList[d]) {
//                    _pageDiv += "<option value='" + component.rowList[d] + "' selected='" + component.pageSize + "'>" + component.rowList[d] + "</option>";
//                } else {
//                    _pageDiv += "<option value='" + component.rowList[d] + "'>" + component.rowList[d] + "</option>";
//                }
//            }
//            _pageDiv += "<select></span>";
//            _pageDiv += "<span id='gridNextPage' onclick='_nextPage(this)' title='Next Page'><i class='fa fa-forward' aria-hidden='true'></i></span>";
//            _pageDiv += "<span id='gridLastPage' onclick='_lastPage(this)' title='Last Page'><i class='fa fa-step-forward' aria-hidden='true'></i></span>";
//            _pageDiv += "</td>";
//            _pageDiv += "<td width='60%' style='direction:rtl'>View " + (((component.pageIndex - 1) * component.pageSize) + 1) + " - " + ((component.pageIndex * component.pageSize) < component.totalRows ? (component.pageIndex * component.pageSize) : component.totalRows) + " of " + component.totalRows + "</td>"
//            _pageDiv += "</tr>";
//            _pageDiv += "</table>";
//            _pageDiv += "</div>";

//            //to bind pageview
//            $("#" + component.pageCtrl).html(_pageDiv);

//            $("#txtPageValue").keypress(function (event) {
//                event = (event) ? event : window.event;
//                var charCode = (event.which) ? event.which : event.keyCode;
//                if (charCode == 13 && event.target.value != '' && event.target.value != null) {
//                    if (parseInt(event.target.value) < 0) {
//                        component.pageIndex = 1;
//                    } else if (parseInt(event.target.value) > component.totalPages) {
//                        component.pageIndex = component.totalPages;
//                    } else {
//                        component.pageIndex = parseInt(event.target.value);
//                    }
//                    _reloadGrid(component);
//                }
//                else if (charCode > 31 && (charCode < 48 || charCode > 57)) {
//                    return false;
//                }
//                return true;
//            });
//        }
//    };
//}
