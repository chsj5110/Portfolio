
package a.a.a.ctr;


import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.UUID;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.multipart.MultipartFile;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.ProjectService;


@Controller
public class ProjectController {
	private static final Logger logger = LoggerFactory.getLogger(ProjectController.class);
	private ModelAndView mv = new ModelAndView();

	@Resource(name = "projectService")
	private ProjectService projectService;
	private ModelAndView addObject;
	

	
	
	@RequestMapping(value = "/post.do", method = RequestMethod.GET)
	public String post() {
		return "body/post";
	}
	
	@RequestMapping(value = "/ReserveSite.do", method = RequestMethod.GET)
	public String reservation() {
		return "body/ReserveSite";
	}
	
	
	@RequestMapping(value = "/Bookmark.do", method = RequestMethod.GET)
	public String Bookmark() {
		return "modal/Bookmark";
	}
	
	@RequestMapping(value = "/board_tag.do", method = RequestMethod.GET)
	public String board_tag() {
		return "board/board_main_tag";
	}
	
	@RequestMapping(value = "/maptest.do", method = RequestMethod.GET)
	public String maptest() {
		return "body/googlemap";
	}
	
	
	
	@RequestMapping(value = "/main/getList.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView getList(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		ArrayList<HashMap<String, Object>> list = projectService.getList(hm);
		System.out.println("get main list");
		mv.addObject("list", list);
		return mv;
	}
	
	
	//---------새 글 등록
	@RequestMapping(value = "/insertnewcontent.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertnewcontent(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
		mv.setViewName("jsonView");
		
		boolean bol = projectService.insertnewcontent(hm);
		
		mv.addObject("addPost", bol);
		
		System.out.println("게시글 입력완료? = " + bol);
		
		return mv;
	}
	
	
	//-------- 조회수
	@RequestMapping(value = "/board/updateViewCnt.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView updateViewCnt(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
		mv.setViewName("jsonView");
		
		boolean bol = projectService.updateViewCnt(hm);
		
		mv.addObject("addcnt", bol);
		
		System.out.println("조회수카운팅? = " + bol);
		
		return mv;
	}
	
	
	
	
	
	//---------------max
	/*
	 * 
	 * NVL(MAX(RB_SEQ)+1, 0) 
	 * 
	 * 
	 * 
	 * 
	 * */
	//--------- 작성글 저장 시 '시퀀스 값 불러와'서 태그도 동시에 저장하기 위함
	@RequestMapping(value = "/board/selectseq.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView getSeqCurrval(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		
		int list = projectService.selectseq();
		System.out.println("==================");
		System.out.println("게시글 번호 : " + list);
		
		mv.addObject("currval", list);
		
		return mv;
	}
	
	

	
	
	
		//////////////////해시태그
		//---------- 해시태그 저장	
		@RequestMapping(value = "/board/inserttag.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView inserttag(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
			mv.setViewName("jsonView");
			
			boolean bol = projectService.inserttag(hm);
			
			mv.addObject("addInfo", bol);
			
			System.out.println("태그입력완료? = " + bol);
			
			return mv;
		}
		
		//--------해시태그 삭제
		@RequestMapping(value = "/board/deletetag.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView deletetag(@RequestBody HashMap<String, Object> hm) throws SQLException {
		
			mv.setViewName("jsonView");
			
			boolean bol = projectService.deletetag(hm);
			
			mv.addObject("removeInfo", bol);
			
			System.out.println("삭제완료?(removeInfo) = " + bol);
			
			return mv;
		}
		
		//---------해당 글의 해시태그 불러옴
		@RequestMapping(value = "/board/gettag.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView gettag(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.gettag(hm);
			
			System.out.println("tag :"+list);
			
			mv.addObject("list", list);
		
		return mv;
		}
	
		
		
		
		
		
		//------- 파일 업로드(리뷰게시판)
		
		@RequestMapping(value="/uploadAjaxAction.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView uploadAjaxAction(@RequestParam(value="uploadFile") MultipartFile[] uploadFile) throws SQLException {
		
			
			mv.setViewName("jsonView");
			
			System.out.println("update ajax post...........");

			// make folder -------------
			
			
			ArrayList<String> array = new ArrayList<String>();
			//ArrayList<HashMap<String, Object>> list = uploadService.uploadfile(hm);
			ArrayList<HashMap<String, Object>> fileInfoarray = new ArrayList<HashMap<String, Object>>();
			
			
			if(uploadFile.length !=0) {
				
				
				
				for (int i = 0; i<uploadFile.length ; i++) {
				
					boolean imgtrue = true;
					
					StringBuffer uploadFolder = new StringBuffer();
					uploadFolder.append("http://192.168.0.119:8090/upload\\");
					//	http://192.168.0.119:8090/main.do
					//	D:upload\\
					// <Context dobBase="http://192.168.0.119:8090 upload" path="/file" reloadable="true"/>
					
					File uploadPath = new File(uploadFolder.toString(), getFolder());
					
					if(uploadPath.exists() == false) {
						uploadPath.mkdirs();
					}
					//make yyyy/MM//dd folder
					
					String urlforhost = getFolder();
					
					// uploadFolder ---------------------------------
					
					
					MultipartFile multipartFile = uploadFile[i];
					
					String uploadFileName = multipartFile.getOriginalFilename();
					
					System.out.println("---------------");
					System.out.println("Upload File Name : " + multipartFile.getOriginalFilename());
					System.out.println("Upload File Size : " + multipartFile.getSize());

					
					// IE has file path
					uploadFileName = uploadFileName.substring(uploadFileName.lastIndexOf("\\") + 1);
					System.out.println("only file name : " + uploadFileName);
					
					UUID uuid = UUID.randomUUID();
					uploadFileName = uuid.toString() + "_" + uploadFileName;
					 
					
					
					try {
						File saveFile = new File(uploadPath, uploadFileName);
						
						multipartFile.transferTo(saveFile);
						
						System.out.println("Upload File Info (Name, Path) : " + uploadFileName +" , "+ uploadPath);
						System.out.println("upload.length = " + uploadFile.length);

						
						
					
						HashMap<String, Object> list = new HashMap<String, Object>();
						
						list.put("FileName_ori", multipartFile.getOriginalFilename());
						list.put("FileName", uploadFileName);
						list.put("uuid", uuid.toString());
						list.put("img", imgtrue);
						list.put("url", uploadPath);
						list.put("urlforhost", urlforhost);
						list.put("filesize", multipartFile.getSize());
						
						fileInfoarray.add(list);
						
						
						System.out.println("list : " + fileInfoarray );
						
					} catch (Exception e) {
						e.printStackTrace();
					} // end catch
				} // end for
				
				
				
			}	//end if
			
			
			mv.addObject("list", fileInfoarray);
			System.out.println("mv : " + mv );
			return mv;		
		}
		
		//--------------------------------------------------------
		
		@RequestMapping(value = "/uploadfile.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView uploadfile(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.uploadfile(hm);
			
			mv.addObject("addFile", bol);
			
			System.out.println("첨부파일 저장완료? = " + bol);
			
			return mv;
		}
		
		
		@RequestMapping(value = "/removeimg.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView removeimg(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.removeimg(hm);
			
			mv.addObject("removeImg", bol);
			
			System.out.println("삭제완료?(removeImg) = " + bol);
			
			return mv;
		}
		
		
		
		
		
		
		//----------------------------------------------------------------------------
		private String getFolder() {
			SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
			
			Date date = new Date();
			
			String str = sdf.format(date);
			
			return str.replace("-", File.separator);
		}
		
		
		private boolean checkImageType(File file) {
			try {
				String contentType = Files.probeContentType(file.toPath());
				
				return contentType.startsWith("image");
			} catch(IOException e) {
				e.printStackTrace();
			}
			return false;
		}

		

		private String toString(StringBuffer uploadFolder) {
			// TODO Auto-generated method stub
			return null;
		}
		
		
		
		@RequestMapping(value = "/main/getChkFileCnt.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView getChkFileCnt(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			ArrayList<HashMap<String, Object>> list = projectService.getChkFileCnt(hm);
			
			System.out.println("파일이 존재? : " + list);
			
			mv.addObject("cnt", list);
			
			return mv;
		}
		
		@RequestMapping(value = "/main/getFileInfo.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView getFileInfo(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			ArrayList<HashMap<String, Object>> list = projectService.getFileInfo(hm);
			
			System.out.println("첨부파일정보 : " + list);
			
			mv.addObject("list", list);
			
			return mv;
		}

		
		//	
		
		// 루트 저장하기
		@RequestMapping(value = "/board/insertRoute.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView insertRoute(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.insertRoute(hm);
			
			mv.addObject("addRoute", bol);
			
			System.out.println("route 입력완료? = " + bol);
			
			return mv;
		}
		


	// 루트 저장시 seq_perplan 먼저 가져오기
		@RequestMapping(value = "/board/selectseqperplan.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectseqperplan(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectseqperplan(hm);
			System.out.println(list);
			mv.addObject("list", list);
		
		return mv;
		}
		
		//------------ 저장된 루트 불러오기
		@RequestMapping(value = "/board/selectRoute.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectRoute(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectRoute(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}
		
		
		
		
		
		//-----------BOOKMARK
		
		@RequestMapping(value = "/board/deleteBookmarkRoute.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView deleteBookmarkRoute(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.deleteBookmarkRoute(hm);
			
			mv.addObject("removeInfo", bol);
			
			System.out.println("삭제완료?(removeInfo) = " + bol);
			
			return mv;
		}
		
		
		@RequestMapping(value = "/board/selectbookmarkseq.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectbookmarkseq(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectbookmarkseq(hm);
			System.out.println(list);
			mv.addObject("list", list);
		
		return mv;
		}
		
		@RequestMapping(value = "/board/insertBookmark.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView insertBookmark(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.insertBookmark(hm);
			
			mv.addObject("addBookmark", bol);
			
			System.out.println("Bookmark 저장완료? = " + bol);
			
			return mv;
		}
		
		@RequestMapping(value = "/board/selectBMRoute1.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectBMRoute1(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectBMRoute1(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}
		
		@RequestMapping(value = "/board/selectBMRoute2.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectBMRoute2(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectBMRoute2(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}
		
		
		@RequestMapping(value = "/board/insertTravelRoute.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView insertTravelRoute(@RequestBody HashMap<String, Object> hm) throws SQLException {
			
			mv.setViewName("jsonView");
			
			boolean bol = projectService.insertTravelRoute(hm);
			
			mv.addObject("addTravelRoute", bol);
			
			System.out.println("Travel Route 저장완료? = " + bol);
			
			return mv;
		}
		
		
		@RequestMapping(value = "/board/selectRouteTR.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView selectRouteTR(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.selectRouteTR(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}
		
		@RequestMapping(value = "/board/getMaxTrday.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView getMaxTrday(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.getMaxTrday(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}
		
		@RequestMapping(value = "/board/getListfromTag.json", method = RequestMethod.POST)
		@ResponseBody
		public ModelAndView getListfromTag(@RequestBody HashMap<String, Object> hm) throws SQLException {
			mv.setViewName("jsonView");
			
			
			ArrayList<HashMap<String, Object>> list = projectService.getListfromTag(hm);
			System.out.println(list);
			mv.addObject("list", list);
			
			return mv;
		}

}
