

//渲染表格
function tabelRender(tableName, id,where, url, toolId, calback) {

    function render(cols) {
        layui.use(['table', 'form', 'jquery', 'common'], function () {
            let table = layui.table;
            table.render({
                elem: '#' + id + '',
                url: url,
                page: true,
                height: 'full-167',
                where: where,
                cols: [cols],
                toolbar: '#' + toolId + '',
                parseData: function (res) { // res 即為原始返回的數據
                    return {
                        "code": res.Code, // 解析接口狀態
                        "msg": res.Msg, // 解析提示文本
                        "count": res.Count, // 解析數據長度
                        "data": res.Data // 解析數據列表
                    };
                },
                defaultToolbar: [{
                    title: l['刷新'],
                    layEvent: 'refresh',
                    icon: 'layui-icon-refresh',
                }, 'exports']
            });

            calback && calback(table);
        });
    }

    //获取表头
    fetch(`/api/ReportSetting/GetLayerTableModels/${tableName}`).
        then(res => res.json()).
        then(render)
}