package a.a.a.ctr;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.AdminService;
import a.a.a.util.PagingVO;

@Controller
public class AdminController {
	
	@Resource(name = "adminService")
	private AdminService adminService;
	
	private static final Logger logger = LoggerFactory.getLogger(AdminController.class);
	private ModelAndView mv = new ModelAndView();
	private ModelAndView mvm = new ModelAndView();

	//회원관리 화면으로 이동
	@RequestMapping(value = "/adminMembership.do", method = RequestMethod.GET)
	public ModelAndView adminMembership(PagingVO vo, @RequestParam(value="nowPage", required=false)String nowPage
			, @RequestParam(value="cntPerPage", required=false)String cntPerPage
			, @RequestParam(value="keyword", required=false)String keyword
			, @RequestParam(value="deleted", required=false)String deleted ) throws SQLException {
		
		mv.setViewName("admin/membership");
		logger.info("회원관리 페이지로 이동중");
		logger.info("mv는"+mv);
		
		if(deleted==null) {
			deleted="1";
		}
		if(keyword==null) {
			keyword="";
		}
		
		HashMap <String, Object> map = new HashMap<String, Object>();
		map.put("searchType", deleted);
		map.put("keyword", keyword);
		
		int total=0;
		
		total = adminService.countMembership(map);	

		logger.info("조건을 만족하는 회원의 수는 "+total);
		if (nowPage == null && cntPerPage == null) {
			nowPage = "1";
			cntPerPage = "20";
		} else if (nowPage == null) {
			nowPage = "1";
		} else if (cntPerPage == null) { 
			cntPerPage = "20";
		}

		vo = new PagingVO(total, Integer.parseInt(nowPage), Integer.parseInt(cntPerPage), keyword, deleted);

		mv.addObject("paging", vo);
	
		ArrayList <HashMap<String,Object>> list = null;

		list = (ArrayList<HashMap<String, Object>>) adminService.adminMembershipList(vo);	

		
		mv.addObject("viewAll", list);
		logger.info("회원 목록은"+list);
		logger.info("페이징은"+vo);
		return mv;
		
	}
	
	//게시글 목록화면으로 이동
	@RequestMapping(value="/adminBoardList.do", method = RequestMethod.GET)
	public ModelAndView boardFB(PagingVO vo, @RequestParam(value="nowPage", required=false)String nowPage
			, @RequestParam(value="cntPerPage", required=false)String cntPerPage
			, @RequestParam(value="keyword", required=false)String keyword
			, @RequestParam(value="type", required=false)String type
			, @RequestParam(value="deleted", required=false)String deleted ) throws SQLException {
		
		mv.setViewName("admin/board");
		
		if(type==null) {
			type="ALL";
		}
		if(deleted==null) {
			deleted="N";
		}
		if(keyword==null) {
			keyword="";
		}
		
		HashMap <String, Object> map = new HashMap<String, Object>();
		map.put("searchType", deleted);
		map.put("keyword", keyword);
		
		int total=0;
		
		  if(type.equals("FB")) { 
			  total = adminService.countListFB(map);
			  } 
		  else if(type.equals("PRV")) { 
			  total = adminService.countListPRV(map);
			  } 
		  else if(type.equals("QB")) { 
			  total = adminService.countListQB(map);
			  } 
		  else if(type.equals("NB")) { 
			  total = adminService.countListNB(map);
			  } 
		  else {	 
			  total = adminService.countList(map);	
			  }

		logger.info("조건을 만족하는 게시글의 수는 "+total);
		if (nowPage == null && cntPerPage == null) {
			nowPage = "1";
			cntPerPage = "20";
		} else if (nowPage == null) {
			nowPage = "1";
		} else if (cntPerPage == null) { 
			cntPerPage = "20";
		}

		vo = new PagingVO(total, Integer.parseInt(nowPage), Integer.parseInt(cntPerPage), keyword, deleted);

		mv.addObject("paging", vo);

		ArrayList <HashMap<String,Object>> list = null;
		 
		  if(type.equals("FB")) { 
			  list = (ArrayList<HashMap<String, Object>>)adminService.adminBoardListFB(vo);
			  } 
		  else if(type.equals("PRV")) { 
			  list = (ArrayList<HashMap<String, Object>>)adminService.adminBoardListPRV(vo);
			  } 
		  else if(type.equals("QB")) { 
			  list = (ArrayList<HashMap<String, Object>>)adminService.adminBoardListQB(vo); 
			  } 
		  else if(type.equals("NB")) { 
			  list = (ArrayList<HashMap<String, Object>>)adminService.adminBoardListNB(vo); 
			  } 
		  else {	 
			  list = (ArrayList<HashMap<String, Object>>) adminService.adminBoardList(vo);	
			  }
		
		mv.addObject("viewAll", list);
		mv.addObject("type",type);
		logger.info("게시글 목록은"+list);
		logger.info("페이징은"+vo);
		return mv;
	}
	
	
	
	
	
	
	//게시글 복구
	@RequestMapping(value = "/restoreBoard.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteFB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		
		mv.setViewName("jsonView");
		String boardtype= (String) hm.get("type");
		
		if(boardtype.equals("FB")) {
			adminService.restoreFB(hm);
		}
		else if(boardtype.equals("PRV")) {
			adminService.restorePRV(hm);
		}
		else if(boardtype.equals("QB")) {
			adminService.restoreQB(hm);
		}
		else if(boardtype.equals("NB")) {
			adminService.restoreNB(hm);
		}
		
		try {		
		logger.info("입력값은"+hm);
		
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	
	//회원 복구
	@RequestMapping(value = "/restoreMembership.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView restoreMembership(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		
		mv.setViewName("jsonView");

		try {		
		logger.info("입력값은"+hm);
		
		adminService.restoreMembership(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}		
		return mv;
	}
	
	
	//회원정보 조회
	@RequestMapping(value = "/adminSelectMembership.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView adminSelectMembership(@RequestBody HashMap<String,Object> hm) throws SQLException{
		
		mv.setViewName("jsonView");
		
		try {
			HashMap <String, Object > map = adminService.adminSelectMembership(hm);
			mv.addObject("data", map);
			mv.addObject("success","Y");
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		
		
		return mv;
	}
}
