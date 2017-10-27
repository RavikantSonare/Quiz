﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Estore.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <!-- Title -->
    <title>Edu Hub - College & Education HTML Template</title>

    <!-- Favicon -->
    <link href="images/apple-icon.png" rel="icon" type="image/png">
    <link href="images/favicon.png" rel="shortcut icon" type="image/png">

    <!-- css file -->
    <link rel="stylesheet" href="css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css">
    <!-- Responsive stylesheet -->
    <link rel="stylesheet" href="css/responsive.css">

    <!-- HTML5 shim and Respond.js for IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
    <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
    <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="preloader"></div>
            <div class="irs-header-topped style2">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-12 col-md-8 col-lg-9 clearfix">
                            <div class="row">
                                <div class="col-xs-12 col-sm-6 col-md-6 irs-padl-zero irs-pl-fftn">
                                    <div class="irs-welcm-ht">
                                        <p class="irs-welcntxt"><i class="fa fa-phone"></i>Any questions? Call us <strong>(012) 345 - 6789</strong> </p>
                                    </div>
                                </div>
                                <div class="col-xs-12 col-sm-6 col-md-6">
                                    <div class="irs-welcm-ht">
                                        <p class="irs-welcntxt"><i class="fa fa-map-marker"></i>4003 Coplin Phoenix, AZ 85040</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-12 col-md-4 col-lg-3 clearfix">
                            <div class="irs-log-reg">
                                <ul class="list-inline">
                                    <li><a href="#">
                                        <div data-toggle="modal" data-target=".bs-example-modal-lg" data-whatever="@mdo">Register or Login</div>
                                    </a>
                                        <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog">
                                            <div class="modal-dialog modal-lg" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title text-center" id="exampleModalLabel">Login or Register</h4>
                                                        <p class="irs-sign-reg-para text-center">Sign in or register today in oorder to have access to all our courses or purchase new ones.</p>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="irs-login-form">
                                                                    <h3>Login <span class="flaticon-padlock"></span></h3>
                                                                    <p>Enter username and password to login:</p>
                                                                    <div class="form-group">
                                                                        <input type="email" class="form-control" id="email2" placeholder="Email">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Password">
                                                                    </div>
                                                                    <button type="submit" class="btn btn-default irs-button-styledark">Login to account</button>
                                                                </div>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <form class="irs-reg-form">
                                                                    <h3>Register <span class="flaticon-key"></span></h3>
                                                                    <p>Join our community today:</p>
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" id="exampleInputNamex" placeholder="First Name">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" id="exampleInputNamexx" placeholder="Last Name">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="email" class="form-control" id="exampleInputEmailx" placeholder="Email">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Password">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Repeat password">
                                                                    </div>
                                                                    <div class="form-group text-center">
                                                                        <button type="submit" class="btn btn-default irs-button-styledark">Sign Me Up</button>
                                                                    </div>
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- modal footer start here-->
                                                </div>
                                            </div>
                                        </div>

                                        <div class="modal fade bs-example-modal-lg2" tabindex="-1" role="dialog">
                                            <div class="modal-dialog modal-lg" role="document">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                        <h4 class="modal-title text-center" id="exampleModalLabel">Student Login or Register</h4>
                                                        <p class="irs-sign-reg-para text-center">Sign in or register today for purchased.</p>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <form class="irs-login-form">
                                                                    
                                                                    <h3>Login <span class="flaticon-padlock"></span></h3>
                                                                    <p>Enter username and password to login:</p>
                                                                    <div class="form-group">
                                                                        <input type="email" class="form-control" id="email2" placeholder="Email">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Password">
                                                                    </div>
                                                                    <button type="submit" class="btn btn-default irs-pricing-btn">Login to account</button>
                                                                </form>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <form class="irs-reg-form">
                                                                    <h3>Register <span class="flaticon-key"></span></h3>
                                                                    <p>Join our community today:</p>
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" id="exampleInputNamex" placeholder="First Name">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="text" class="form-control" id="exampleInputNamexx" placeholder="Last Name">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="email" class="form-control" id="exampleInputEmailx" placeholder="Email">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Password">
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <input type="password" class="form-control" placeholder="Repeat password">
                                                                    </div>
                                                                    <div class="form-group text-center">
                                                                        <button type="submit" class="btn btn-default irs-pricing-btn">Sign Me Up</button>
                                                                    </div>
                                                                </form>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <!-- modal footer start here-->
                                                </div>
                                            </div>
                                        </div>

                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Header Styles -->
            <div class="header-nav style2">
                <div class="main-header-nav scrollingto-fixed style2">
                    <div class="container">
                        <nav class="navbar navbar-default bootsnav irs-menu-style-two yellow">
                            <div class="container irs-pad-zero">
                                <!-- Start Header Navigation -->
                                <div class="navbar-header">
                                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-menu"><i class="fa fa-bars"></i></button>
                                    <a class="navbar-brand" href="#brand">
                                        <img src="images/header-logo-l2.png" class="logo" alt="header-logo-l2.png"></a>
                                </div>
                                <!-- End Header Navigation -->

                                <!-- Collect the nav links, forms, and other content for toggling -->
                                <div class="collapse navbar-collapse" id="navbar-menu">
                                    <ul class="nav navbar-nav navbar-center">
                                        <li><a href="#" class="dropdown-toggle active" data-toggle="dropdown">Home</a>

                                        </li>
                                        <li><a href="page-faq.html">Faq</a></li>
                                        <li><a href="page-careers.html">Careers</a></li>
                                        <li><a href="#">
                                            <div data-toggle="modal" data-target=".bs-example-modal-lg2" data-whatever="@mdo">Student Register or Login</div>
                                        </a></li>

                                        <li><a href="CHECKOUT.html">Check OUT</a></li>
                                    </ul>
                                </div>
                                <!-- /.navbar-collapse -->
                            </div>
                        </nav>
                    </div>
                </div>
            </div>

            <!-- Breadcrumbs Styles -->
            <section class="irs-ip-breadcrumbs">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-lg-offset-3 text-center">
                            <h1 class="irs-bc-title">Courses</h1>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Breadcrumbs html -->
            <section class="irs-ip-brdcrumb">
                <div class="container">
                    <div class="row"></div>
                </div>
            </section>



            <!-- Social Media Section -->
            <section class="irs-client">
                <div class="container">
                    <div class="row irs-mrgnt">
                        <div class="col-md-2 col-md-offset-2 clearfix animatedParent">
                            <div class="irs-clients-thumb text-center animated growIn">Total Merchant<p>50,000</p>
                            </div>
                        </div>
                        <div class="col-md-2 clearfix animatedParent">
                            <div class="irs-clients-thumb text-center animated growIn">Total Students<p>500,000</p>
                            </div>
                        </div>
                        <div class="col-md-2 clearfix animatedParent">
                            <div class="irs-clients-thumb text-center animated growIn">Total Exams<p>10,000</p>
                            </div>
                        </div>
                        <div class="col-md-2 clearfix animatedParent">
                            <div class="irs-clients-thumb text-center animated growIn">Total Questions<p>5,000,000</p>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Footer Section -->
            <section class="irs-footer style2">
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12 col-sm-6 col-md-2 col-lg-2">
                            <div class="irs-footer-useful-link style2">
                                <h3 class="irs-mrgnbot-fourty irs-ftl-bottom">Useful Links</h3>
                                <ul class="irs-list-square style2">
                                    <li><a href="#">Become a Teacher</a></li>
                                    <li><a href="#">Careers</a></li>
                                    <li><a href="#">FAQ</a></li>
                                    <li><a href="#">Our Blog</a></li>
                                    <li><a href="#">Our Events</a></li>
                                    <li><a href="#">Our Courses</a></li>
                                    <li><a href="#">Contact Us</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                            <div class="irs-footer-newslatter">
                                <h3 class="irs-mrgnbot-fourty irs-ftl-bottom">Newsletter</h3>
                                <div class="irs-nl-details">
                                    <h4>Get our latest news and <span>free courses</span> directly on your email:</h4>
                                    <form class="irs-newlatter-form">
                                        <div class="form-group">
                                            <input type="text" class="form-control" placeholder="Name">
                                        </div>
                                        <div class="form-group">
                                            <input type="email" class="form-control" id="email" placeholder="Email">
                                        </div>
                                    </form>
                                    <a href="#" class="btn btn-sm irs-btn-thm2"><span class="flaticon-multimedia"></span>Subscribe Me</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-3 col-lg-3">
                            <div class="irs-footer-latest-news">
                                <h3 class="irs-mrgnbot-fourty irs-ftl-bottom">Latest News</h3>
                                <div class="irs-fln-details">
                                    <div class="irs-fln-thumb pull-left clearfix">
                                        <img src="images/blog/xs1.png" alt="xs1.png">
                                        <div class="irs-fln-overlay"><span class="flaticon-cross"></span></div>
                                    </div>
                                    <div class="irs-fln-ttl clearfix">
                                        <h5>Rhetoric for the Voiceless: A different way</h5>
                                        <p class="irs-fln-date"><span class="flaticon-clock"></span>21/02/2017</p>
                                    </div>
                                    <div class="irs-fln-thumb pull-left clearfix">
                                        <img src="images/blog/xs2.png" alt="xs2.png">
                                        <div class="irs-fln-overlay"><span class="flaticon-cross"></span></div>
                                    </div>
                                    <div class="irs-fln-ttl clearfix">
                                        <h5>Wednesday Lunchtime Organ Recital Series: TBC</h5>
                                        <p class="irs-fln-date"><span class="flaticon-clock"></span>19/02/2017</p>
                                    </div>
                                    <div class="irs-fln-thumb pull-left clearfix">
                                        <img src="images/blog/xs3.png" alt="xs3.png">
                                        <div class="irs-fln-overlay"><span class="flaticon-cross"></span></div>
                                    </div>
                                    <div class="irs-fln-ttl clearfix">
                                        <h5>Small Animal Hospital Public Lecture</h5>
                                        <p class="irs-fln-date"><span class="flaticon-clock"></span>17/02/2017</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-xs-12 col-sm-6 col-md-4 col-lg-3 col-lg-offset-1">
                            <div class="irs-footer-beteacher">
                                <h3 class="irs-mrgnbot-fourty irs-ftl-bottom">Become a Teacher</h3>
                                <div class="irs-fbteacher">
                                    <div class="irs-fbt-thumb">
                                        <img class="img-responsive img-fluid" src="images/team/s1.png" alt="s1.png">
                                    </div>
                                    <h4>Become a teacher today and start working at <span>Edu Hub</span> University.</h4>
                                    <a href="#" class="btn btn-sm irs-btn-thm"><span>Become a Teacher</span></a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            <!-- Our CopyRight Section -->
            <section class="irs-copy-right">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <p>Irstheme Copyright© 2017 All Rights Received. Designed with <i class="fa fa-heart"></i><span class="text-thm2">diadea3007</span></p>
                        </div>
                    </div>
                </div>
            </section>
            <a class="scrollToTop" href="#"><i class="fa fa-angle-up"></i></a>
        </div>
        <!-- Wrapper End -->
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type="text/javascript" src="js/jquery-ui.min.js"></script>
        <script type="text/javascript" src="js/bootstrap.min.js"></script>
        <script type="text/javascript" src="js/bootsnav.js"></script>
        <script type="text/javascript" src="js/scrollto.js"></script>
        <script type="text/javascript" src="js/jquery-scrolltofixed-min.js"></script>
        <script type="text/javascript" src="js/jquery-SmoothScroll-min.js"></script>
        <script type="text/javascript" src="js/jquery.counterup.js"></script>
        <script type="text/javascript" src="js/fancybox.js"></script>
        <script type="text/javascript" src="js/wow.min.js"></script>
        <script type="text/javascript" src="js/jquery.masonry.min.js"></script>
        <script type="text/javascript" src="js/jquery.magnific-popup.min.js"></script>
        <script type="text/javascript" src="js/owl.carousel.min.js"></script>
        <script type="text/javascript" src="js/jquery.fitvids.js"></script>
        <script type="text/javascript" src="js/css3-animate-it.js"></script>
        <script type="text/javascript" src="js/swiper.min.js"></script>
        <script type="text/javascript" src="js/flipclock.min.js"></script>
        <!-- Custom script for all pages -->
        <script type="text/javascript" src="js/script.js"></script>
    </form>
</body>
</html>
