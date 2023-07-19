# 实体生成器
> .net5的winform窗体实现，生成器模式(Builder Pattern)，依赖很基础，可随意变更框架，如net6，net7
## 写在前面
因为老项目要改造，用新项目重构，数据库是现成的，但一个个手动创建实体类很麻烦，所以决定利用业余时间，做个东西出来。  
  
EFCore本身自带生成实体类功能，教程参考[这里](https://www.cnblogs.com/gaoxiong666/p/15018956.html)。由于生成出来的实体是在Context类OnModelCreating方法里加映射(Fluent API)，表多的话代码会很多，而且实体字段没有注释，DbSet变量名总是结尾加s的复数形式，我更喜欢用特性约束，且有注释，然后为了解决以上痛点，写了这个生成器。  
  
注：  
1.EFCore的生成有分词功能，单词首字母大写，这个还没有实现，目前只是首字母大写和遇下划线后的首字母大写  
2.目前支持的数据库只有Oracle和SqlServer，扩展别的库在DataBase文件夹实现接口就行  
3.目前待优化的地方，是在循环里查询，这样第一次会很慢，还缺一个批量查询，减少查数据库的次数
## 效果展示
图就在上面Image文件夹里，如果看不见可能需要挂全局代理  
![image](https://github.com/GaoXiong666/CreateEntity/blob/main/Image/123.png)
## 更新日志
2021.07.09--新增Oracle数据库的实体类生成  
2021.10.10--新增SqlServer数据库的实体类生成  
2021.10.13--新增是否替换现有文件功能  
2021.10.14--新增是否添加上下文功能(如输入DefaultDbContext，生成的文件就是DefaultDbContext.cs)
