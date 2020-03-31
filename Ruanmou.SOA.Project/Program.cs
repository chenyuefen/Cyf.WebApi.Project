using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ruanmou.SOA.Project
{
    /// <summary>
    /// 1 SOA的思想，分布式服务
    /// 2 WebService声明调用授权，Remoting比较
    /// 3 单元测试服务调用
    /// 
    /// SOA:面向服务架构，是构造分布式系统的方法论，也会提供一些标准、工具。
    /// 
    /// WebService:寄宿在IIS，也就是必须在网站项目
    /// Http协议  SOAP协议
    /// 1 Http传输信道，A服务器到B服务器，数据是什么格式传递的
    /// 2 XML的数据格式---Http传输解析得到的有用数据
    /// 3 SOAP协议---封装格式：在分布式的环境中，描述了如何做数据交换的一个轻量级协议
    /// 4 WSDL：属于webservice的标配，标准化描述服务，方便调用
    /// 5 UDDI：根据描述查找服务的机制
    /// 
    /// 服务端调用WebService添加服务引用，基于svcUtil.exe生成的
    /// 基于wsdl生成的一个代理：屏蔽服务调用的复杂性
    /// 
    /// 单元测试：测试方法---回归测试
    /// 
    /// WebService安全认证：
    /// Form认证  windows认证
    /// 服务方法里面添加账号密码参数
    /// SoapHeader验证
    /// 
    /// 1 WCF声明&调用
    /// 2 多宿主多协议配置
    /// 3 WCF双工协议
    /// 
    /// 
    /// WCF是.NetFramework3.5 被称之为分布式服务的集大成者
    /// 支持不同的协议:http  tcp IPC MSMQ p2p
    /// 支持不同的宿主：网站 控制台  winform  WindowsService
    /// 双工
    /// 
    /// 
    /// 1 抽象接口--ServiceContract
    ///   方法---OperationContract--没有不行
    /// 2 实体--没有任何标记---数据全部返回(无参数构造函数) 
    ///   实体没有无参数构造  需要添加DataContract
    ///   类上面有DataContract，那么元素需要[DataMember],否则不可见
    ///   真实工作中，都会带上DataContract * DataMember
    ///   
    /// WCF托管在控制台(Winform--WindowsService)
    ///    1 配置文件
    ///    2 ServiceHost实例open(注意权限)
    ///    
    /// tcp协议 速度快点，不能穿防火墙，有状态
    /// 
    /// WCF+WindowsService--定时调度
    /// 
    /// WCF/WebService泛型怎么弄
    /// 泛型，不行！
    /// 
    /// 那我确实要返回不同的表的数据，要写多个方法吗
    /// 习惯性WCF调用参数只有一个，是序列化后的json/xml，扩展性强，不会因为参数而需要更新
    /// 就是在序列化信息里面描述清楚，返回结果也是序列化后
    /// 
    /// 
    /// 安全(WCF一般是给后端用的，但是也支持ajax)：
    /// 1 没有身份验证--局域网后台调用
    /// 2 发布口令--请求式加个参数(事先约定)
    /// 3 soapheader--用户的账号密码
    /// 4 Windows 身份验证
    /// 5 X509证书
    /// 
    /// 
    /// WCF双工协议：相互通信--IM
    /// http就不行，无状态   tcp/pipeline
    /// 核心思路就是回调
    /// 1 服务接口上约定，CallbackContract(回调接口)
    /// 2 回调接口里面方法需要IsOneWay=true
    /// 3 启动服务，客户端引用服务，实现回调接口
    /// 4 调用服务时，讲回调方法传递进去
    /// 不仅是客户端可以向服务端发消息，而且服务端可以主动向客户端发消息
    /// 
    /// 
    /// 1 RESTful架构风格和WebApi
    /// 2 WebApi路由&特性路由
    /// 3 WebApi依赖注入&面向切面
    /// 
    /// 能听见我说话的，能看到我桌面的，而且不卡的，刷个1
    /// 高级班的传统，准备好学习的小伙伴儿，给Eleven老师刷一个专属字母E，然后课程就正式开始了！！！
    /// 
    /// WebService--->WCF--->WebApi
    /// RESTful架构风格:表现层的状态转化， 是一个接口的设计风格
    ///    资源：万物看成资源，
    ///    统一接口：CRUD增删改查，跟HTTP Method对应
    ///              Create--Post    Read--Get   Update--Put/Patch  Delete--Delete
    ///    URI:统一资源定位符，资源对应的唯一地址
    ///    无状态：基于Http协议， (登陆系统--查询工资--计算税收，有状态)
    ///            无状态的直接一个地址，就能拿到工资，就能得到税收
    ///            
    /// WebService---http协议，soap协议，只能IIS承载，入门简单，XML跨平台
    /// WCF---集大成者，多种协议，多种宿主，整合了RPC。
    /// RPC模式，都是调用方法的，
    /// 
    /// WebApi:RESTful,http协议 无状态 标准化操作  更轻量级，尤其是json，适合移动端
    /// 
    /// 
    /// 网站启动时执行Application_Start---给Routes增加地址规则---请求进来时--会经过路由匹配找到合适的《控制器》
    /// 那怎么找的Action？
    ///    1 根据HttpMethod找方法---用的方法名字开头，Get就是对应Get请求
    ///    2 如果名字不是Get开头，可以加上[HttpGet]
    ///    3 按照参数找最吻合
    /// 
    /// 其实资源是这样定义的，不是一个学生，而可能是一个学校
    ///  可能是一个订单--多件商品，一次查询，订单-商品，数据之前嵌套关系很复杂
    /// 还有个特性路由！可以单独订制
    /// 1 config.MapHttpAttributeRoutes();
    /// 2 标记特性
    /// 
    /// 版本兼容---约束路由---默认值/可空路由---多数据
    /// 
    /// 
    /// IOC容器+配置文件初始化
    /// 控制器也要注入--完成容器和WebApi框架融合--实现IDependencyResolver，将容器放进去--初始化讲 config.DependencyResolver 换成自定义的Resolver
    /// 
    /// 
    /// 
    /// 1 WebApi前台调用详析
    /// 2 WebApi后台调用详析
    /// 3 Basic授权认证&权限Filter
    /// 
    /// 
    /// 1 建立Controller--
    /// 2 因为是教学演示，控制器里面没有遵循restful--增加一个类似mvc的路由
    /// 3 UI对方法的AJAX调用
    /// 
    /// 前端调用
    /// 后端HttpClient调用
    /// 后端HttpWebRequest调用
    /// 
    /// 权限认证：是需要的，http地址，是公开的，所以需要权限认证
    /// session--webapi默认是不支持session--RESTful---可以自行扩展去支持
    /// 无状态：第2次请求和第1次请求不关联
    /// 1 登陆过程，拿到令牌--token--ticket--许可证
    /// 2 验证成功--账号+密码+其他信息+时间--加密一下得到ticket---返回给客户端
    /// 3 请求时，ajax里面带上这个ticket（header）
    /// 4 接口调用时，就去验证ticket，解密一下，看看信息，看看时间
    /// 5 每个方法都验证下ticket？就可以基于filter来实现
    /// 
    /// 后端调用时，授权认证的演示
    /// 
    /// 
    /// 1 异常处理Filter和ActionFilter
    /// 2 WebApi跨域请求
    /// 3 自宿主WebApi实现
    /// 4 自动生成WebApi文档
    /// 
    /// 继承ExceptionFilterAttribute覆写OnException---标记到需要的控制器action---注册到全局
    /// Filter的范围仅仅局限在Action里面
    /// 
    /// 找不到方法--404--控制器构造失败
    /// 全局处理：
    /// 继承ExceptionHandler，覆写Handle---初始化项目时，服务替换上
    /// 暂未实现！暂未实现！暂未实现！
    /// 
    /// ActionFilter 可以在Aciton前/后分别增加逻辑---想象力先留给大家
    /// 
    /// 8088是VS启动，Express承载的
    /// 9099是IIS承载的，
    /// 二者是同一套代码
    /// 
    /// 不指定域名-端口时，ajax是直接调用当前的域名+端口
    /// 跨域请求：浏览器请求时，如果A网站(域名+端口)页面里面，通过XHR请求B域名，这个就是跨域
    ///           这个请求是可以正常到达B服务器后端，正常的相应(200)
    ///           但是，浏览器不允许这样操作，除非在相应里面有声明（Access-Control-Allow-Origin）
    /// 浏览器同源策略：处于安全考虑，浏览器限制脚本去发起跨站请求
    ///           但是，页面是js/css/图片/iframe 这些是浏览器自己发起的，是可以跨域的 
    /// 
    /// 它的核心就在于它认为自任何站点装载的信赖内容是不安全的。当被浏览器半信半疑的脚本运行在沙箱时，它们应该只被允许访问来自同一站点的资源，而不是那些来自其它站点可能怀有恶意的资源。
    /// 
    /// 
    /// JSONP---脚本标签自动请求--请求回来的内容执行个回调方法---解析数据
    /// CORS 跨域资源共享，允许服务器在响应头里面指定Access-Control-Allow-Origin，浏览器按照响应来操作
    ///    nuget-cors-初始化配置下，支持跨域
    ///    自定义actionfilter--response增加头文件Access-Control-Allow-Origin
    ///    
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("欢迎来到.Net高级班VIP课程，今晚是Eleven老师为你带来的SOA系列课程");

                ServiceInit.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
