# 实体生成器
> .net5的winform窗体实现，生成器模式(Builder Pattern)，依赖很基础，可随意变更框架，如net6，net7
## 写在前面
以前公司的orm框架用的是十分冷门的NPoco，而且作为业务驱动型公司，你懂的，新加表，表加字段，是家常便饭，这就非常麻烦，新加个表要在代码里加实体类，加TableMapping，建provider类，在DbContext里建字段，建属性，等等！忍受了2个月，跟老大商量以后，开始把项目升级为.net core，orm用EFCore，数据库都是现成的，所以依然采用db first的方式。  
  
EFCore本身自带生成实体类功能，教程参考[这里](https://www.cnblogs.com/gaoxiong666/p/15018956.html)。由于生成出来的实体是在Context类OnModelCreating方法里加映射(Fluent API)，表多的话代码会很多，而且实体字段没有注释，DbSet变量名总是结尾加s的复数形式，我更喜欢用特性约束，且有注释，然后为了解决以上痛点，写了这个生成器。  
  
注：EFCore的生成有分词功能，这个还没有实现，目前还是干巴巴的首字母大写和遇下划线后的首字母大写
## 效果展示
![image](https://github.com/GaoXiong666/CreateEntity/blob/main/Image/123.png)
## 更新日志
2021.07.09--新增Oracle数据库的实体类生成  
2021.10.10--新增SqlServer数据库的实体类生成  
2021.10.13--新增是否替换现有文件功能  
2021.10.14--新增是否添加上下文功能
