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
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.QnaBoardService;
import a.a.a.util.PagingVO;

@Controller
public class QnaBoardController {
	
	@Resource(name = "qnaBoardService")
	private QnaBoardService qnaBoardService;
	
	private static final Logger logger = LoggerFactory.getLogger(QnaBoardController.class);
	private ModelAndView mv = new ModelAndView();

	
	//Q&A 게시판 이동후 페이징 처리해서 목록보기
	@RequestMapping(value="/qnaBoard.do", method = RequestMethod.GET)
	public ModelAndView boardFB(PagingVO vo, @RequestParam(value="nowPage", required=false)String nowPage
			, @RequestParam(value="cntPerPage", required=false)String cntPerPage
			, @RequestParam(value="keyword", required=false)String keyword
			, @RequestParam(value="searchType", required=false)String searchType) throws SQLException {
		
		mv.setViewName("QnaBoard/qnaBoard");
		
		int total = qnaBoardService.countQB(vo);
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
		mv.addObject("viewAll", qnaBoardService.selectQB(vo));
		
		logger.info("mv는"+mv);
		return mv;
	}
	
	//Q&A 등록화면으로 이동
	@RequestMapping(value = "/insertQB.do", method = RequestMethod.GET)
	public String toInsertQB(Locale locale, Model model) {
		return "QnaBoard/insertQB";
	}

	//Q&A 조회 페이지 이동
	@RequestMapping(value = "/readQB.do", method = RequestMethod.GET)
	public ModelAndView toReadQB(String seq, HttpServletRequest request) {
		mv.setViewName("QnaBoard/readQB");
		logger.info(seq);
		mv.addObject("seq", seq);
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");
		String userId= request.getRemoteUser();
		
		mv.addObject("userId",userId);
		mv.addObject("isAdmin",isAdmin);
		
		logger.info("Q&A조회 페이지로 이동중");
		logger.info("mv는"+mv);
		return mv;
	}
	
	//Q&A 조회
	@RequestMapping(value = "/readQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView readQB(@RequestBody HashMap<String,Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		HashMap<String,Object> list = qnaBoardService.readQB(hm);
		mv.addObject("data", list);	
		logger.info("조회된 데이터는"+list);
		return mv;
	}
	
	

	//Q&A 수정 화면으로 이동
	@RequestMapping(value = "/updateQB.do", method = RequestMethod.GET)
	public ModelAndView toUpdateQB(String seq) {
		mv.setViewName("QnaBoard/insertQB");
		logger.info(seq);
		mv.addObject("seq", seq);
		logger.info("Q&A수정 페이지로 이동중");
		logger.info("mv는"+mv);
		return mv;
	}
	
	//Q&A 등록하기
	@RequestMapping(value = "/insertQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertQB(@RequestBody HashMap<String,Object> hm, Principal principal)  throws SQLException{
		logger.info("Q&A 등록중");
		mv.setViewName("jsonView");
		
		try {
		
		String user_id = principal.getName();
		
		hm.put("writer", user_id);
		
		logger.info("입력값은"+hm);
		
		qnaBoardService.insertQB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//Q&A 수정
	@RequestMapping(value = "/updateQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView updateQB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("Q&A 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		qnaBoardService.updateQB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//Q&A 삭제
	@RequestMapping(value = "/deleteQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteQB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("Q&A 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		qnaBoardService.deleteQB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//Q&A 답변 등록하기
	@RequestMapping(value = "/answerInsertQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView answerInsertQB(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("Q&A 답변 등록중");
		mv.setViewName("jsonView");
		
		try {
		
		logger.info("입력값은"+hm);
		
		qnaBoardService.answerInsertQB(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}
	
	//Q&A답변 조회
	@RequestMapping(value = "/answerShowQB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView answerShowQB(@RequestBody HashMap<String,Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		logger.info("조회된 데이터는"+mv);
		try {
		logger.info("Q&A 답변 조회중");
		ArrayList<HashMap<String, Object>> list = qnaBoardService.answerShowQB(hm);
		mv.addObject("list", list);	

		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		mv.addObject("success","Y");
		logger.info("조회된 데이터는"+mv);
		return mv;
	}	
	
	//Q&A답변 삭제
	@RequestMapping(value = "/deleteAnswer.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteAnswer(@RequestBody HashMap<String,Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		logger.info("조회된 데이터는"+mv);
		try {
		logger.info("Q&A 답변 삭제중");
		qnaBoardService.deleteAnswer(hm);

		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		mv.addObject("success","Y");
		logger.info("조회된 데이터는"+mv);
		return mv;
	}	
}