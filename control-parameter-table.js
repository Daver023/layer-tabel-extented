let actions = {
    add_contro_parameter(obj = {}) {

        showDialog('新增', 800, 480, `/Setting/ReportControlEdit?id=${obj.data ? obj.data.Id : ''}`);
    },
    remove(obj) {
        let id = obj.data.Id;
        deleteData(`/api/ReportSetting/Control/Delete/${id}`, {}, function () {
            debugger;
            layer.closeAll();
            let $ = getJquery();
            $('#sertch').click();
        });
    },
    delete_contro_parameter(obj) {
        deleteData('/api/ReportSetting/Control/Delete-List', getIds()
            , function (res) {
                debugger;
                let $ = getJquery();
                $('#sertch').click();
            });
        
    }
}

function callback(obj) {
    if (actions[obj.event]) {
        actions[obj.event](obj);
    }
}

function getIds() {
    let idsArray = [];
    var checkStatus = layui.table.checkStatus('control-parameter-table'); //demo 即为基础参数 id 对应的值
    if (checkStatus.data.length > 0) {
        for (var i = 0; i < checkStatus.data.length; i++) {
            idsArray.push(checkStatus.data[i].Id);
        }
    }
    return idsArray;
}


tabelRender('ReportControlEntity', 'control-parameter-table', { }, '/api/ReportSetting/Control/List', 'control-parameter-table-station-toolbar', function (tabel) {
    tabel.on('toolbar(control-parameter-table)', callback);
    tabel.on('tool(control-parameter-table)', callback);
    layui.common.tabels['control-parameter-table'] = tabel;
    let $ = getJquery();
    $('#sertch').click(function () {
        let Project = $('#ProjectName').val();
        tabel.reload('control-parameter-table', { where: { Project: Project }});
    })
});



