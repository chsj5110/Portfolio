<%@ page language="java" contentType="text/html; charset=EUC-KR"
    pageEncoding="EUC-KR"%>

<link href="/../../resources/css/boardDisplay.css" rel="stylesheet">
 
<!-- ����Ʈ ����Ʈ ���̺귯�� -->
<script type="text/javascript" src="/../../resources/se2/js/HuskyEZCreator.js" charset="utf-8"></script>

<script>
	$(document).ready(function() {
		var dataInfo=null;

		var json={};
		
		json.seq="${seq}"
		
		//seq ���翩�� Ȯ��
		if(json.seq!="") {
			dataInfo=getAjax("./readFB.json",json).data;
			
			$("#inputTitle").val(dataInfo.FB_TITLE);
			$("#smartEditor").val(dataInfo.FB_CONTENT);
		}	
		
		$("#insertFB").on("click", function(){
			json.title=$("#inputTitle").val();

			//����Ʈ�����Ϳ� �� ���� �������� ��ũ��Ʈ �ڵ�
			oEditors.getById["smartEditor"].exec("UPDATE_CONTENTS_FIELD", []);
			
			json.content=$("#smartEditor").val();
			json.date = nowDate();
	
			json.openChk=$('input[name="openChk"]:checked').val();	
			
			console.log(json);
			
			if (json.title==""||json.content==""){
				alert("�����̳� ������ �Է����� �ʾҽ��ϴ�.")
			} else {
				dataInfo=null;
				
				//seq ���翩�ο� ���� ���/���� ����
				if(json.seq!=""){			
					dataInfo=getAjax("./updateFB.json",json);
				} else {
					dataInfo=getAjax("./insertFB.json",json);
				}
								
				if (dataInfo.success=="Y"){
					alert("�Խñ��� ��ϵǾ����ϴ�.")
					if(json.seq!="") {
						location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";				
					} else {
						location.href="./freeBoard.do";
					}
				} else {
					alert("����(200byte)�̳� ����(4000byte)�� ��� ���ڼ��� �ʰ��Ͽ����ϴ�.");
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
		
		$("#insertCancelFB").on("click", function(){
			if(json.seq!="") {
				location.href="./freeBoard.do?nowPage=${paging.nowPage}&cntPerPage=${paging.cntPerPage}&keyword=${paging.keyword}&searchType=${paging.searchType}";
			} else {
				location.href="./freeBoard.do";
			}
		})
	
	});
</script>


<div class="content">
	<div style=" max-width:1000px;">
			<label><input type="radio" name="openChk" value="Y" checked>����</label><br>
			<label><input type="radio" name="openChk" value="N">�����</label>
			<div id="openChkText" style='color:red; display:none;'>*������� �����Ұ�� �����ڿ� �۾��̸� �� ���� ���� �ֽ��ϴ�.</div>
		<br>
		<div>
			<input type="text" id="inputTitle" style="width:80%;" placeholder="������ �Է��ϼ���">
		</div>
		<br>	
		
		<!-- ����Ʈ ������ �ؽ�Ʈ ���� -->
		<div class="jsx-2303464893 editor"> 
			<div class="fr-box fr-basic fr-top" role="application"> 
				<div class="fr-wrapper show-placeholder" dir="auto" style="overflow: scroll;"> 
					<textarea name="notice_content" id="smartEditor" style="width:100%;min-width:100px;min-height:300px;"></textarea> 
				</div> 
			</div> 
		</div>
		<br>
		<div>
			<button id="insertFB">���</button> <button id="insertCancelFB">���</button>
		</div>
	</div>
</div>

<!-- ����Ʈ ����Ʈ ��ũ��Ʈ *�ݵ�� ����Ʈ ������ �ؽ�Ʈ ���� �ؿ� ��ġ�ؾ� �� -->
<script type="text/javascript" src="/../../resources/js/se2/se2.js" charset="utf-8"></script>

