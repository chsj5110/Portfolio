package a.a.a.ctr;

import java.security.Principal;
import java.sql.SQLException;
import java.text.DateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.CommentService;
import a.a.a.service.FreeBoardService;

@Controller
public class CommentController {
	
	@Resource(name = "commentService")
	private CommentService commentService;
	
	private static final Logger logger = LoggerFactory.getLogger(CommentController.class);
	private ModelAndView mv = new ModelAndView();

	
//자유 게시판 댓글	
	//댓글 등록하기
	@RequestMapping(value = "/insertCommentFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertCommentFB(@RequestBody HashMap<String, Object>hm, Principal principal) throws SQLException {
		
		mv.setViewName("jsonView");
		logger.info("등록할 댓글은"+hm);
		
		String user_id = principal.getName();		
		hm.put("writer", user_id);
		
		try {
			commentService.insertCommentFB(hm);		
			mv.addObject("success","Y");
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		return mv;
	}
	
	//댓글 수 조회하기
	@RequestMapping(value = "/countCommentFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView countComment(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		logger.info("입력값:"+hm);
		try {
			Integer cnt = commentService.countCommentFB(hm);
			mv.addObject("cnt", cnt);	
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		mv.addObject("success","Y");
		return mv;
	}	
	
	//댓글 조회하기
	@RequestMapping(value = "/commentListFB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView commentList(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		logger.info("입력값:"+hm);
		try {
			ArrayList<HashMap<String, Object>> list = commentService.commentListFB(hm);
			mv.addObject("list", list);	
			
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
			
		}
		mv.addObject("success","Y");
		logger.info("조회된 데이터는"+mv);
		return mv;
	}
	
	
	//댓글 1개 삭제하기
	@RequestMapping(value = "/deleteComment.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView deleteComment(@RequestBody HashMap<String, Object>hm) throws SQLException {
		
		try {
			mv.setViewName("jsonView");
			logger.info("삭제할 댓글번호는"+hm);
			commentService.deleteComment(hm);
			mv.addObject("success","Y");
			
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		
		return mv;
	}
	
	
	
//리뷰 게시판 댓글	
	//댓글 등록하기
	@RequestMapping(value = "/insertCommentRB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView insertCommentRB(@RequestBody HashMap<String, Object>hm, Principal principal) throws SQLException {
		
		mv.setViewName("jsonView");
		logger.info("등록할 댓글은"+hm);
		
		String user_id = principal.getName();		
		hm.put("writer", user_id);
		
		try {
			commentService.insertCommentRB(hm);		
			mv.addObject("success","Y");
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
		}
		return mv;
	}
	
	
	//댓글 조회하기
	@RequestMapping(value = "/commentListRB.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView commentListRB(@RequestBody HashMap<String, Object> hm) throws SQLException {
		mv.setViewName("jsonView");
		logger.info("입력값:"+hm);
		try {
			ArrayList<HashMap<String, Object>> list = commentService.commentListRB(hm);
			mv.addObject("list", list);	
			
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success","N");
			
		}
		mv.addObject("success","Y");
		logger.info("조회된 데이터는"+mv);
		return mv;
	}
}