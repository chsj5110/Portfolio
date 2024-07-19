 <%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" language="java" %>
 
 
 
<div class="modal-header">
	<h4>게시글 작성하기</h4>
</div>
<div class="modal-body">
	<form role="form" action="/project/main" method="get">
		<div class="form-group">
			<lable> 카테고리 </lable>
			<select name="category" id="category" style="width:105px;">
							<option value="0">선택하세요</option>
							<option value="여행계획">여행계획</option>
							<option value="여행후기">여행후기</option>
			</select>
			<lable> 글 공개 여부 </lable>
			<select name="openchk" id="openchk" style="width:105px;">
							<option value="0">선택하세요</option>
							<option value="Y">Y</option>
							<option value="N">N</option>
			</select>
			
		</div>
		<div class="form-group">
			<lable> 제목 </lable>
			<input type="text" class="form-control" name="title" id="title" autocomplete="off">
		</div>
		<div class="form-group">
			<lable> 내용 </lable>
			<input type="text" class="form-control" name="content" id="content" autocomplete="off" style="height : 300px;">
		</div>
		<div class="form-group">
			<lable> 작성자 </lable>
			<input type="text" class="form-control" name="writer" id="writer" autocomplete="off">
		</div>
		<div class="form-group">
			<lable> 태그입력 </lable>
			<input type="text" class="form-control" name="inserttag" id="inserttag" autocomplete="off" placeholder="#로 태그를 구분해주세요">
		</div>
		<div class="form-group">
			<lable> 파일 첨부하기 </lable>
				<div  class='uploadDiv'>
					<input type="file" name="uploadFile" multiple="multiple" accept="image/*" id="myfileinput"/>
				</div>
				<div id="thumbnailImgs">
				</div>
		</div>
	</form>
</div>
<div class="modal-footer">
	<button type="button" class="btn btn-default" id="cancleBtn" >취소</button>
	<button type="button" class="btn btn-default" id="resetBtn" >초기화</button>
	<button type="submit" class="btn btn-primary" id="registerBtn">작성완료</button>
</div>

<script src="http://code.jquery.com/jquery-latest.min.js"></script>
<script src="../../resources/js/common/common.js" type="text/javascript"></script>
	<script type="text/javascript">

	
	$(document).ready(function(){
		
		//첨부파일 관련
		//---------------------------
		var regex = new RegExp("(.*?)\.(exe|sh|zip|alz)$");
		var maxSize = 5242880;
		
		function checkExtension(fileName, fileSize){
			
			if(fileSize >= maxSize){
				alert("파일 사이즈 초과");
				return false;
			}
			
			if(regex.test(fileName)){
				alert("해당 종류의 파일은 업로드할수 없습니다.");
				return false;
			}
			
			return true;
		}
		
		//------------------------------------------------------
		
	
		
		var cloneObj = $(".uploadDiv").clone();
		
		
		//------------------------------------------------------
		
		
		var file = document.querySelector('#myfileinput');
		
		
		$(document).on('change', '#myfileinput', function(){
			$("#thumbnailImgs").empty();
			$(".uploadResult ul").empty();
    	// @breif 업로드 파일 읽기
		let fileList = document.getElementById( "myfileinput" ).files;
		// @breif 업로드 파일 읽기

			function readAndPreview( fileList ) {
			// @breif 이미지 확장자 검사
			
				if ( /\.(jpe?g|png|gif)$/i.test( fileList.name ) ) {
					
					let reader = new FileReader();
					
					reader.addEventListener( "load", function() {
						
						let image = new Image();
						image.width = "100";
						image.height = "100";
						image.title = fileList.name;
						image.src = this.result;
						// @details 이미지 확장자 검사
						document.getElementById( "thumbnailImgs" ).appendChild( image );
					}, false );
					// @details readAsDataURL( )을 통해 파일의 URL을 읽어온다.
	
					if( fileList ) {
						reader.readAsDataURL( fileList );
					}
	
				} else {
					let reader = new FileReader();
					
					reader.addEventListener( "load", function() {
						
						let image = new Image();
						image.width = "100";
						image.height = "100";
						image.title = fileList.name;
						image.src = "/resources/img/attach.png";
						// @details 이미지 확장자 검사
						document.getElementById( "thumbnailImgs" ).appendChild( image );
					}, false );
					// @details readAsDataURL( )을 통해 파일의 URL을 읽어온다.
	
					if( fileList ) {
						reader.readAsDataURL( fileList );
					}
				}

			}
    		if( fileList ) {
                // @details readAndPreview() 함수를 forEach문을통한 반복 수행
				[].forEach.call( fileList, readAndPreview );

        	}

    	});
		$("#cancleBtn").on("click", function(){
			location.href = "/main.do";
							// 또는 /board_main.do
		});
		// 취소버튼
		
		
		$("#resetBtn").on("click", function(){
			$('input[name=title]').val("");
			$('input[name=content]').val("");
			$('input[name=writer]').val("");
			$('input[name=inserttag]').val("");
			$('#myfileinput').val("");						// 초기화 시 첨부파일 및 썸네일도 초기화
			$("#thumbnailImgs").empty();
		});
		// 초기화 버튼

		
		
		
		$("#registerBtn").on("click", function(){
			
			var title = $("#title").val();
			var content = $("#content").val();
			var writer = $("#writer").val();
			var fileupload = $("#myfileinput").val();
			var category = $('#category').val();
			var openchk = $('#openchk').val();
			
			if(title == ""){
				alert("글의 제목을 입력해주세요.");
				return false;
			}else if(content == "") {
				alert("글의 내용을 입력해주세요.");
				return false;
			}else if(writer ==""){
				alert("작성자를 입력해주세요.");
				return false;
			} else if(category=="0"){
				alert("카테고리를 선택해주세요.")
				return false;
			}else if(openchk=="0"){
				alert("글의 공개여부를 선택해주세요.")
				return false;
			}else{}
			
			
			
			var json={};
			var data = getAjax("./selectseq.json", json)
			var rbseq = data.currval
			console.log(data.currval);
			
			
			//--------------------게시글 등록 ajax start
			var json={};
			
			json.title = title;
			json.content = content;
			json.writer = writer;
			json.openchk = openchk;
			json.category = category;
			
			var data = getAjax("./insertnewcontent.json", json)
			
			
			
			////////////---------------태그저장
			var inserttag = $("#inserttag").val();
			var a = inserttag.replace(/(\s*)/g, "") 
			var splstr = a.split('#');
			json= {};
			
			console.log(a);
			console.log(splstr);
			
			json.rbseq = rbseq;
			for(i=1 ; i<splstr.length;i++){
				json.tag = splstr[i];
				var data = getAjax("./inserttag.json", json)
			}
			console.log(json.rbseq);
			
			
			
			//----------------첨부파일 존재시, 첨부파일 저장  ajax start
			if(myfileinput != 0){
				
				var formData = new FormData();
				var inputFile = $("input[name='uploadFile']");
				var files = inputFile[0].files;
				
				console.log(files);
				
				
				for(var i=0 ; i<files.length ; i++){
					
					if(!checkExtension(files[i].name, files[i].size)){
						return false;
					}
					
					formData.append("uploadFile", files[i]);
				}
				
				console.log(formData.get("uploadFile"));
				
				
				var json={};
				$.ajax({
					url : '/uploadAjaxAction.json',
					processData : false,
					contentType : false,
					data : formData,
					dataType : 'json',
					type : 'POST',
					async:false,
					success : function(data){
						
						var listArray = data.list;
						console.log(data);
						
						html = "";
						
						
						for(i = 0; i < data.list.length; i++){
							
							console.log(data.list[i].FileName_ori);
							
							if(data.list[i].img == true){
								html += "<li'>" 
										+ data.list[i].FileName_ori + "</li>";
								
								
							}else {
								html +=	"<li'>"
										+ data.list[i].FileName_ori + "</li>";
							}
							
							//----------------------------
							
							json={};
							var filenameorg = data.list[i].FileName_ori;
							var filenameuuid =  data.list[i].uuid;
							var fileurl = data.list[i].url;
							var urlforhost = data.list[i].urlforhost;
							var filesize = data.list[i].filesize;
							
							
							json.rbseq = rbseq;
							json.filenameorg = filenameorg;
							json.filenameuuid = filenameuuid;
							json.fileurl = fileurl;
							json.filesize = filesize;
							//json.urlforhost = urlforhost;
						
							var data = getAjax("./uploadfile.json", json);	
							console.log("안녕");
							
							
							
						} // for end
						
						
						
						$("#thumbnailImgs").empty();
						
						
						$(".uploadDiv").html(cloneObj.html());
						
						
					}, 
					error: function(jqXHR, textStatus, errorThrown) { 
						console.log(jqXHR.responseText); 
					
					}
				
				
				}); // 첨부파일 ajax end
				
			}// 첨부파일 존재시 if end
			
			
			if(data.addPost == true){
				
				if(data.addTag != false){
					if(data.addFile != false){
						alert("게시글 작성이 완료되었습니다. main으로 돌아갑니다.");
						location.href = "./main.do";
					}else{
						alert("첨부파일 등록에 실패하였습니다");
						return;
					}
				}else{
					alert("태그 등록에 실패하였습니다.");
					return;
				}
				
			} else{
				return;
			}
			
			
			
		});/////등록버튼 온클릭
		
		
		
		
						
	});//document ready - end
	
	
</script>