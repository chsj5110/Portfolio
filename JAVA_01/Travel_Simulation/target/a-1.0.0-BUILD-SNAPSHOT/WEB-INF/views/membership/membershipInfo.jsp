<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>

<style>
.contentBox {
	max-width: 600px;
	margin:auto;
	padding: 30px;
	height:100vw;
}

.tag {
	text-align: center;
}
td{
	text-align:left;
}
.memBtnSet {
	text-align: right;
}






</style>

<script>
	$(document).ready(
			function() {
				
				$(".contentBox").html(getHtml("/memInfo.do"));
				
				var json={};
				
				var dataInfo=null;
				dataInfo=getAjax("./memberShipSelect.json",json);
				
				var Info=null;
				Info=dataInfo.data;
				$("#showId").html(Info.M_ID);
				$("#showName").html(Info.M_NAME);
				$("#showEmail").html(Info.M_EMAIL);
				$("#showInterest").html(Info.M_INTEREST);
				$("#membershipCreateDate").html(Info.M_CREATEDATE);
				$(".memBtnSet").append("<button class='btn btn-primary memeberDelete' value='"+Info.M_SEQ+"'>회원탈퇴</button>");
				//메인화면 이동
				
				$("#showBookmark").on("click", function(){
					
					var mid=Info.M_ID;
					console.log(mid);
					window.open("./Bookmark.do?userId="+mid, "북마크 새창", "width=800, height=700, toolbar=no, menubar=no, scrollbars=no, resizable=yes" );  

				});
				
				
				
				
				 $(".close").click(function() {
				      $("#modalPost").css({
				        "display": "none"
				      });
				    });
				
				$(".toMainBtn").on("click",	function() {
					location.href="./main.do";
				});
				
				//회원탈퇴
				$(".memeberDelete").on("click",	function() {
					if(confirm("정말로 탈퇴하시겠습니까?")){
						var jsond={};
						jsond.date = nowDate();
						jsond.seq=this.value;
						var data= getAjax("./deleteMembership.json",jsond);
						if(data.success=="Y"){
							$("#logoutDiv").show();
							$("#logoutBtn").click();
						} else{
							alert("탈퇴하지 못했습니다.");
						}
					}	
				});
				
				$("#toMembershipUdateBtn").on("click", function(){
					location.href="./memberShipMove.do";
				});
			});
</script>



	<div class="contentBox">


	</div>
