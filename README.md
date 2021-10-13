# 实体生成器
> VS2019开发，.net5的winform窗体实现，生成器模式(Builder Pattern)
## 写在前面
以前公司的orm框架用的是十分冷门的NPoco，而且作为业务驱动型公司，你懂的，新加表，表加字段，是家常便饭，这就非常麻烦，新加个表要在代码里加实体类，加TableMapping，建provider类，在DbContext里建字段，建属性，等等！忍受了2个月，跟老大商量以后，开始把项目升级为.net core，orm用EFCore。  
  
EFCore本身自带生成实体类功能，教程参考[这里](https://www.cnblogs.com/gaoxiong666/p/15018956.html)。由于生成出来的实体是在Context类OnModelCreating方法里加映射，表多的话代码会巨多，而且实体字段没有注释，我更喜欢用特性约束，且加注释，于是本生成器诞生，是我喜欢的模样。
##效果展示
![图片](https://github.com/GaoXiong666/CreateEntity/Image/123.png)
## 更新日志
2021.07.09--实现了Oracle数据库的实体类生成  
2021.10.10--实现了SqlServer数据库的实体类生成  
2021.10.13--添加是否替换现有文件功能  
