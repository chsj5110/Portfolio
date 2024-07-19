package a.a.a.ctr;

import java.sql.SQLException;
import java.util.HashMap;
import java.util.Locale;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.FreeBoardService;
import a.a.a.util.PagingVO;

@Controller
public class FreeBoardController {
	
	@Resource(name = "freeBoardService")
	private FreeBoardService freeBoardService;
	
	private static final Logger logger = LoggerFactory.getLogger(FreeBoardController.class);
	private ModelAndView mv = new ModelAndView();

	
	//게시글 목록화면으로 이동
	@RequestMapping(value="/freeBoard.do", method = RequestMethod.GET)
	public ModelAndView boardFB(PagingVO vo, @RequestParam(value="nowPage", required=false)String nowPage
			, @RequestParam(value="cntPerPage", required=false)String cntPerPage
			, @RequestParam(value="keyword", required=false)String keyword
			, @RequestParam(value="searchType", required=false)String searchType) throws SQLException {
		
		mv.setViewName("FreeBoard/freeBoard");
		
		int total = freeBoardService.countFB(vo);
		logger.info("조건을 만족하는 게시글의 수는 "+total);
		if (nowPage == null && cntPerPage == null) {
			nowPage = "1";
			cntPerPage = "5";
		} else if (nowPage == null) {
			nowPage = "1";
		} else if (cntPerPage == null) { 
			cntPerPage = "5";
		}
		vo = new PagingVO(total, Integer.parseInt(nowPage), Integer.parseInt(cntPerPage), keyword, searchType);
		mv.addObject("paging", vo);
		mv.addObject("viewAll", freeBoardService.selectFB(vo));
		
		logger.info("mv는"+mv);
		return mv;
	}
	
	
	//게시글 등록화면으로 이동
	@RequestMapping(value = "/insertFB.do", method = RequestMethod.GET)
	public String toInsertFB(Locale locale, Model model) {
		return "FreeBoard/insertFB";
	}

	//게시글 조회 페이지 이동
	@RequestMapping(value = "/readFB.do", method = RequestMethod.GET)
	public ModelAndView toReadFB(String seq , HttpServletRequest request) {
		mv.setViewName("FreeBoard/readFB");
		logger.info(seq);
		mv.addObject("seq", seq);
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");
		String userId= request.getRemoteUser();
		
		mv.addObject("userId",userId);
		mv.addObject("isAdmin",isAdmin);
		
		logger.info("게시글조회 페이지로 이동중");
		logger.info("mv는"+mv);
		return mv;
	}
	
	//게시글 조회
	@RequestMapping(value = "/readFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView readFB(@RequestBody HashMap<String,Object> map) throws SQLException {	
		logger.info("게시글 조회 시작");
		mv.setViewName("jsonView");
		HashMap<String,Object> list = freeBoardService.readFB(map);
		mv.addObject("data", list);	
		logger.info("조회된 데이터는"+list);
		return mv;
	}
	
	

	//게시글 수정 화면으로 이동
	@RequestMapping(value = "/updateFB.do", method = RequestMethod.GET)
	public ModelAndView toUpdateFB(String seq, HttpServletRequest request) throws SQLException {
		
		String user_id= request.getRemoteUser();
		
		HashMap<String,Object> map = new HashMap<String,Object>();
		map.put("seq", seq);
		HashMap<String,Object> list = freeBoardService.readFB(map);
		String id=list.get("M_ID").toString();
		
		logger.info("id:"+id +" user_id:"+user_id);
		
		if(user_id.equals(id)) {
			mv.setViewName("FreeBoard/insertFB");
			mv.addObject("seq", seq);
			logger.info("게시글수정 페이지로 이동중");
		} else {
			mv.setViewName("login/accessError");
		}			
		logger.info("mv는"+mv);
		return mv;
	}
	
	//게시글 등록하기
	@RequestMapping(value = "/insertFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertFB(@RequestBody HashMap<String,Object> map, HttpServletRequest request)  throws SQLException{
		logger.info("게시글 등록중");
		mv.setViewName("jsonView");
		
		try {
		
		String user_id= request.getRemoteUser();
		
		map.put("writer", user_id);
		
		logger.info("입력값은"+map);
		
		freeBoardService.insertFB(map);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//게시글 수정
	@RequestMapping(value = "/updateFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView updateFB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("게시글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		freeBoardService.updateFB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//게시글 삭제
	@RequestMapping(value = "/deleteFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteFB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("게시글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		freeBoardService.deleteFB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	

}