package a.a.a.ctr;

import java.security.Principal;
import java.sql.SQLException;
import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.NoticeBoardService;
import a.a.a.util.PagingVO;

@Controller
public class NoticeBoardController {
	
	@Resource(name = "noticeBoardService")
	private NoticeBoardService noticeBoardService;
	
	private static final Logger logger = LoggerFactory.getLogger(NoticeBoardController.class);
	private ModelAndView mv = new ModelAndView();

	
	//공지사항 목록보기
	@RequestMapping(value="/noticeBoard.do", method = RequestMethod.GET)
	public ModelAndView boardNB(PagingVO vo, @RequestParam(value="nowPage", required=false)String nowPage
			, @RequestParam(value="cntPerPage", required=false)String cntPerPage
			, @RequestParam(value="keyword", required=false)String keyword
			, @RequestParam(value="serachType", required=false)String searchType) throws SQLException {
		
		mv.setViewName("NoticeBoard/noticeBoard");
		
		int total = noticeBoardService.countNB();
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
		mv.addObject("viewAll", noticeBoardService.selectNB(vo));
		
		logger.info("mv는"+mv);
		return mv;
	}
	
	//공지글 등록화면으로 이동
	@RequestMapping(value = "/adminInsertNB.do", method = RequestMethod.GET)
	public String toInsertNB(Locale locale, Model model) {
		return "NoticeBoard/insertNB";
	}

	//공지글 조회 페이지 이동
	@RequestMapping(value = "/readNB.do", method = RequestMethod.GET)
	public ModelAndView toReadNB(String seq, HttpServletRequest request) {
		mv.setViewName("NoticeBoard/readNB");
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");
		mv.addObject("isAdmin",isAdmin);
		
		logger.info(seq);
		mv.addObject("seq", seq);
		logger.info("공지글조회 페이지로 이동중");
		logger.info("mv는"+mv);
		return mv;
	}
	
	//공지글 조회
	@RequestMapping(value = "/readNB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView readNB(@RequestBody HashMap<String,Object> map) throws SQLException {
		mv.setViewName("jsonView");
		HashMap<String,Object> list = noticeBoardService.readNB(map);
		mv.addObject("data", list);	
		logger.info("조회된 데이터는"+list);
		return mv;
	}
	
	//공지글 수정 화면으로 이동
	@RequestMapping(value = "/adminUpdateNB.do", method = RequestMethod.GET)
	public ModelAndView toUpdateNB(String seq, HttpServletRequest request) throws SQLException {
		
		boolean re = request.isUserInRole("ROLE_ADMIN");
		if(re==true) {
			mv.setViewName("NoticeBoard/insertNB");
			mv.addObject("seq", seq);
			logger.info("공지글수정 페이지로 이동중");
		} else {
			mv.setViewName("login/accessError");
		}			
		logger.info("mv는"+mv);
		return mv;
	}

	//전체 공지글 목록 표시
	@RequestMapping(value = "/NBList.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView NBList() throws SQLException {
		mv.setViewName("jsonView");
		ArrayList list = noticeBoardService.NBList();
		mv.addObject("data", list);	
		logger.info("리스트는"+list);
		return mv;
	}
	
	//공지글 등록하기
	@RequestMapping(value = "/insertNB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertNB(@RequestBody HashMap<String,Object> map)  throws SQLException{
		logger.info("공지글 등록중");
		mv.setViewName("jsonView");
		
		try {
		
		logger.info("입력값은"+map);
		
		noticeBoardService.insertNB(map);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//공지글 수정
	@RequestMapping(value = "/updateNB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView updateNB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("공지글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		noticeBoardService.updateNB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}	
		return mv;
	}
	
	//공지글 삭제
	@RequestMapping(value = "/deleteNB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteNB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("공지글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		noticeBoardService.deleteNB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
}