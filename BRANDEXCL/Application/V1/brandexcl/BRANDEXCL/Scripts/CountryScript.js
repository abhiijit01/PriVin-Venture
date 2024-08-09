
$(function () {
    
    $("#jqGrid").jqGrid({
        url: "/Admin/Country/ViewCountry1",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['Country Id', 'Country Name'],
        colModel: [
            {name:"Con_Id" ,editable: true, key: true, index: 'Con_Id', editoptions: { readonly: "readonly" }, search: false },
            { key:false, name: 'Con_Nm', index: 'Con_Nm', editable: true }],      
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        width: '100%',
        viewrecords: true,
        caption: 'Country Records',
        emptyrecords: 'No Country Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Con_Id: "0"
        },
        autowidth: true,
        multiselect: false
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Admin/Country/UpdateCountry',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Admin/Country/InsertCountry",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Admin/Country/DeleteCountry/",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Student... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});