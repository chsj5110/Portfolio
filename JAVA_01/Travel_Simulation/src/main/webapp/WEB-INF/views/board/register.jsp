<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<script src="../../resources/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>	
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
<script type="text/javascript">
  $(document).ready(function(){
	  var json = {};
	  $.ajax({
			type: 'POST',
			url:"/board/registerLastSeq.json",
			data: JSON.stringify(json),
			datatype : "json",
			async : false,
			contentType: 'application/json; charset:utf-8',
			success: function(data){
				//alert("리뷰글 번호 = " + data.registerLastSeq);
				boardseq = data.registerLastSeq;
			}
		});
	
	  $("#boardSeq").append(boardseq);
	  $("#reviewtextbtn").hide();
	  
	  $("#Savebtn").on("click",function(){
  			alert("저장 버튼");
  			var insertTitle      = $("#title").val();
  			var insertContent    = $("#Content").val();

  			console.log(insertTitle);
  			console.log(insertContent);
  			
  			$("#aa").remove();
  			
	  	 	var html="";
	  		html += "<div id='bb'>";
	  		html += "<div class='form-group'>";
	  		html += 	"<h4 id='Title'></h4>";
	  		html += "</div>";
	  		html += "<div class='form-group'>";
	  		html += 	"<p id='Content'></p>";
	  		html += "</div>";
	  		html += "<button type:'button' id='modifybtn'>수정</button>"	
	  		html += "</div>"; 

 	  		$("#review").append(html);
	  		$("#Title").append(insertTitle);
  			$("#Content").append(insertContent);
  			
	  		json.Bno        = boardseq;
  			json.Title  	= insertTitle;
  			json.Content	= insertContent;
  			console.log(json);
  			$.ajax({
  				type: 'POST',
				url:"/board/register.json",
				data: JSON.stringify(json),
				datatype : "json",
				async : false,
				contentType: 'application/json; charset:utf-8',
				success: function(data){
					alert("저장됨");
				} 
			}); 

  			$("#modifybtn").on("click",function(){
  				alert("수정");
  				$("#text_div").remove();
  				$("#text_div").load("register.do");
  			})
  		});
	  $("#closebtn").on("click",function(){
			alert("닫기 버튼");
			$("#aa").remove();
			$("#reviewtextbtn").show();
  		}); 
	  
  });

</script>
<body>
			<div id='aa'>
			<div class='form-group' style='margin-bottom: 0px;'>
  			<label style="display: none;">번호</label>
            <font class="text-gray-900" id="boardSeq" style="display: none;"></font>
  			<div class='form-group' style='margin-bottom: 0px;'>
  			<label>제목</label>
  			<input class='form-control' id='title'></input>
  			</div>
  			<div class='form-group'>
  			<label>내용</label>
  			<textarea style='resize: none; height: 62px;' class='form-control' id='Content'></textarea>
  			</div>
  			<button type='button' id='Savebtn'>저장</button>
  			<button type='button' id='closebtn'>닫기</button>	
  			</div>
  			</div>
</body>
</html>