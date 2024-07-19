<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>


<link href="/../../resources/css/boardDisplay.css" rel="stylesheet">


<style>

.se2_inputarea img { max-width:100%; } 

</style>

<!-- 스마트 에디트 라이브러리 -->
<script type="text/javascript" src="/../../resources/se2/js/HuskyEZCreator.js" charset="utf-8"></script>

<script>
	$(document).ready(function() {
		var json={};
		
		json.seq="${seq}"
		
		//seq 존재여부 확인
		if(json.seq!="") {
			alert("seq가 존재합니다.");
			
			var dataInfo=null;
			dataInfo=getAjax("./readNB.json",json).data;
			$("#inputTitle").val(dataInfo.NB_TITLE);
			$("#smartEditor").val(dataInfo.NB_CONTENT);
		}	
		
		$("#insertNB").on("click", function(){
			json.title=$("#inputTitle").val();
			
			//스마트에디터에 쓴 글을 가져오는 스크립트 코드
			oEditors.getById["smartEditor"].exec("UPDATE_CONTENTS_FIELD", []);
			
			json.content=$("#smartEditor").val();
			json.date = nowDate();
			json.openChk=$('input[name="openChk"]:checked').val();	
			
			if (json.title==""||json.content==""){
				alert("제목이나 내용을 입력하지 않았습니다.")
			} else {
			
				dataInfo=null;
				
				if(json.seq!=""){			
					dataInfo=getAjax("./updateNB.json",json);
				} else {
					dataInfo=getAjax("./insertNB.json",json);
				}
								
				if (dataInfo.success=="Y"){
					alert("게시글이 등록되었습니다.")
					if(json.seq!="") {
						location.href="./noticeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}";				
					} else {
						location.href="./noticeBoard.do";
					}
				} else {
					alert("제목(200byte)이나 본문(4000byte)의 허용 글자수를 초과하였습니다.");
				}	
			}
		});

		
		$('input[name="openChk"]').on('click', function() {
		    var valueCheck = $('input[name="openChk"]:checked').val();
		    if ( valueCheck == 'Y' ) {
		        $('#openChkText').hide();
		    } else if ( valueCheck == 'N' ) {
		    	$('#openChkText').show();
		    }
		});
		
		$("#insertCancelNB").on("click", function(){
			if(json.seq!="") {
				location.href="./noticeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}";				
			} else {
				location.href="./noticeBoard.do";
			}
		})
	
	});
</script>

<div class="content">
	<div style=" max-width:1000px;">
			<label><input type="radio" name="openChk" value="Y" checked>공개</label><br>
			<label><input type="radio" name="openChk" value="N">비공개</label>
			<div id="openChkText" style='color:red; display:none;'>*비공개를 선택할경우 관리자와 글쓴이만 이 글을 볼수 있습니다.</div>
		<br>
		<div>
			<input type="text" id="inputTitle" style="width:80%;" placeholder="제목을 입력하세요">
		</div>
		<br>
		<!-- 스마트 에디터 텍스트 상자 -->
		<div class="jsx-2303464893 editor"> 
			<div class="fr-box fr-basic fr-top" role="application"> 
				<div class="fr-wrapper show-placeholder" dir="auto" style="overflow: scroll;"> 
					<textarea name="notice_content" id="smartEditor" style="width:100%;min-width:100px;min-height:300px;"></textarea> 
				</div> 
			</div> 
		</div>
		<br>
		<div>
			<button id="insertNB">등록</button> <button id="insertCancelNB">취소</button>
		</div>
	</div>
</div>

<!-- 스마트 에디트 스크립트 *반드시 스마트 에디터 텍스트 상자 밑에 위치해야 함 -->
<script type="text/javascript" src="/../../resources/js/se2/se2.js" charset="utf-8"></script>

