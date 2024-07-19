<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="sec"
    uri="http://www.springframework.org/security/tags"%>
    

  

  

<style>
	/* 넥슨 배찌체  (http://levelup.nexon.com/font/index.aspx?page=3)*/
	@font-face { 
		font-family: 'Bazzi'; 
		src: url('resources/font/Bazzi.ttf') format('truetype'); 
	} 

	.bg-dark {
    	background-color: white !important;
	}
	#floating-panel {
        position: absolute;
        top: 10px;
        left: 15%;
        z-index: 5;
        background-color: #fff;
        padding: 5px;
        border: 1px solid #999;
        text-align: center;
        font-family: 'Roboto','sans-serif';
        line-height: 30px;
        padding-left: 10px;
      }
	.nav-link{
		font-size:1.1em;
	}
      
      #map {
        float: center;
        width: 100%;
        height: 600px;
      }

	
	#board td {
			border: 1px solid #bcbcbc;
	}

	.trip_seq{
    text-align: left;
    color:blue;
}
.trip_title{
	text-align: left;	
}
.imgUl {
    list-style:none;
    margin:0;
    padding:0;
    width:100%;
    display:flex;
}

.imgLi {
    margin: 0 0 0 3%;
    padding: 0 0 0 0;
    border : 0;
    float: left;
    width:30%;
}

	.starRev{
	text-align: center;
	}
	
 
	.starR1{ 
     background: url('http://miuu227.godohosting.com/images/icon/ico_review.png') no-repeat -52px 0; 
     background-size: auto 100%; 
     width: 10px;
     height: 20px; 
     float:left; 
     text-indent: -9999px; 
     cursor: pointer; 
     background-position: -35px;
     display: inline-block;
 } 
 .starR2{ 
     background: url('http://miuu227.godohosting.com/images/icon/ico_review.png') no-repeat right 0; 
     background-size: auto 100%; 
     width: 10px;
     height: 20px; 
     float:left; 
     text-indent: -9999px; 
     cursor: pointer; 
     background-position: -45px 0;
     display: inline-block;
 } 
 .starR1.on{
 	background-position:0 0;
 } 
 .starR2.on{
 	background-position:-10px 0;
 } 


/* 	@media (min-width: 576px) {
		#locationSerch{
		    margin-top: 56px;
		}
	}
	
	@media (min-width: 768px) {
		#locationSerch{
		    margin-top: 56px;
		}
	}
	
	@media (min-width: 992px) {
		#locationSerch{
		    margin-top: 56px;
		}
	}
	
	@media (min-width: 1200px) {
		#locationSerch{
		    margin-top: 56px;
		}
	} */
	
</style>
<script src="../../resources/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
<script type="text/javascript">
$(document).ready(function(){
	$("#navbarBtn").click(function() {
			body();
	});
	
	$('details').on('click', function() {
		$('details').not($(this)).removeAttr('open');
	});
});

function body() {
	$("#bodyLayout").click(function(){
		if($("#navbarResponsive").hasClass("navbar-collapse collapse show")) {
			$("#navbarBtn").click();
		}
	});
}
</script>


  <!-- Navigation -->
	<nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
		<div class="container">
			<a class="navbar-brand" href="./main.do" style="font-weight: inherit;color: #611f1f;">Travel Simulation</a>
			<button class="navbar-toggler" id="navbarBtn" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
				<span class="navbar-toggler-icon"><img src="resources/img/menu_ico.png" style="width:30px; height:30px;"></span>
			</button>
			<div class="collapse navbar-collapse" id="navbarResponsive">
				<ul class="navbar-nav ml-auto">
				
<!-- 					<li class="nav-item active">
						<a class="nav-link" href="./main.do">Home
							<span class="sr-only">(current)</span>
						</a>
					</li> -->
					
					<li class="nav-item">
						<a class="nav-link" href="./ReserveSite.do">예약 사이트</a>
					</li>
					
					<li class="nav-item">
						<a class="nav-link" href="./recomm.do">추천 여행지</a>
					</li>
					
					<li class="nav-item">
						<a class="nav-link" href="./board_main.do">리뷰</a>
					</li>
					

  
					<li class="nav-item">
						<details>
							<summary class="nav-link">커뮤니티</summary>
								<div class="nav-item">
									<a class="nav-link" href="./freeBoard.do">자유 게시판</a>
								</div>
					  			<div>
					  				<a class="nav-link" href="./noticeBoard.do">공지사항</a>
					 	 		</div>
								<div>
								   	<a class="nav-link" href="./qnaBoard.do">Q&A</a>
								</div>   			 
					 	</details>
					</li>
  					
					<sec:authorize access="isAnonymous()">
						<li class="nav-item">
							<a class="nav-link" href="./login.do">로그인</a>
						</li>
					</sec:authorize>
					
					
					<sec:authorize access="hasAnyRole('ROLE_MEMBER','ROLE_ADMIN')">
						<details>
							<summary class="nav-link">마이페이지</summary>
							<li class="nav-item">
								<a class="nav-link" href="./membershipInfo.do">회원정보</a>
							</li>
							<li class="nav-item">
								<a class="nav-link" href="#" onclick="$('#logout-form').submit();">로그아웃</a>
								<form id="logout-form" action='/logout.do' method="POST">
									<input name="${_csrf.parameterName}" type="hidden" value="${_csrf.token}"/>
								</form>
							</li>
						</details>
					</sec:authorize>	
					<sec:authorize access="hasRole('ROLE_ADMIN')">
						<details>
							<summary class="nav-link">관리자 페이지</summary>
							<li class="nav-item">
								<a class="nav-link" href="./adminMembership.do">회원 관리</a>				
							</li>
							<li class="nav-item">
								<a class="nav-link" href="adminBoardList.do">게시글 관리</a>
							</li>
							<li>
					  			<a class="nav-link" href="/adminInserthotel.do">호텔 정보 추가</a>
					 	 	</li>
					 	 	<li>
					  			<a class="nav-link" href="/adminIntest.do">관광지 정보 추가</a>
					 	 	</li>
						</details>
					</sec:authorize>	
				</ul>
			</div>
		</div>
	</nav>
	
	
	<!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
  <div class="modal-dialog" style="max-width:800px;">
    <div class="modal-content">
      <div class="modal-header">
      <h4 class="modal-title" style="text-align: center; line-height: 1.5;" id="myModalLabel"></h4>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
      </div>
      <div class="modal-body" id="insertModal">
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<!--End Modal-->
	