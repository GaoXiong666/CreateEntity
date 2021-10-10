# 实体生成器
##写在前面
以前公司的orm框架用的是十分冷门的NPoco，而且作为业务驱动型公司，你懂的，新加表，表加字段，改字段类型，是家常便饭，这就非常麻烦，新加个表要在代码里加实体类，加TableMapping，在DbContext里加字段，建属性，建provider类，等等！忍受了2个月，跟老大商量以后，开始把项目框架升级为.net core，orm框架用EFCore。  
请注意，EFCore框架本身自带根据数据库生成实体类功能，教程参考[这里](https://www.cnblogs.com/gaoxiong666/p/15018956.html)。由于框架生成出来的实体是在Context类OnModelCreating方法里加映射，表多的话代码会很多，而且实体类的字段没有注释(Oracle数据库加注释很方便，但它没生成出来)，我更喜欢用特性约束，且加注释，于是本生成器诞生，是我喜欢的模样。
  
c#，生成器模式(Builder Pattern)  
.net5的winform窗体实现(不建议用，拖控件没有framework丝滑)  
  
##更新日志
2021.07.09--实现了Oracle数据库的实体类生成  
2021.10.10--实现了SqlServer数据库的实体类生成
