# layer-tabel-extented
基于layer 表格的扩展
1 使用方式 第一个文件  后台返回列名的方法
![image](https://github.com/user-attachments/assets/11c4c77e-eb19-4714-a3f0-65f949386dfc)
在这个方法中 我们通过传入一个实体的类名称获取实体中所有的字段名称 在实体的属性上面定义一个自定义属性
![image](https://github.com/user-attachments/assets/f8576c84-7681-4162-80d4-40b419502bea)
layer的扩展属性 分别对应了 列名 列宽 是否显示 工具模板ID 居中方式 模板ID 字典 这个字段是什么类型  是checkbox 还是raidoBox
![image](https://github.com/user-attachments/assets/027ce0d8-26cb-4c31-9540-88ecc229ed58)
2 第二个文件时前端粉装的js组件
![image](https://github.com/user-attachments/assets/ded2cfd1-cfc2-4c02-af8c-949200126e65)
从左到右的参数分别是
需要获取列名的实体名称 当前需要渲染的表格ID 搜索参数 后台获取表格对应数据的url  layer对应的工具条ID  回调函数

代码是体现个人的想法 我提交一个想法  希望大家能多多指正一下。感谢

代码是在另一个分支里面  这里面是说明
