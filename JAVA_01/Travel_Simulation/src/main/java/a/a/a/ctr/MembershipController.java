package a.a.a.ctr;

import java.sql.SQLException;
import java.util.HashMap;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.MembershipService;


@Controller
public class MembershipController {

	@Resource(name = "membershipService")
	private MembershipService membershipService;
	
	@Autowired
	BCryptPasswordEncoder passwordEncoder;
	
	private static final Logger logger = LoggerFactory.getLogger(MembershipController.class);
	private ModelAndView mv = new ModelAndView();
	

	
	@RequestMapping(value = "/memberShipMove.do")
	public ModelAndView memBerShipMove( HttpServletRequest request) {
		logger.info("회원가입으로 이동중");
		
		boolean isMember= request.isUserInRole("ROLE_MEMBER");
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");
		
		mv.addObject("isMember", isMember);
		mv.addObject("isAdmin", isAdmin);
		
		mv.setViewName("membership/membership");
		
		return mv;
	}
	
	@RequestMapping(value = "/membershipInfo.do")
	public String membershipInfo() {
		logger.info("회원가입으로 이동중");
		return "membership/membershipInfo";
	}
	
	@RequestMapping(value = "/memberShipUpdateMove.do")
	public String memBerShipUpdateMove() {
		logger.info("회원정보 수정페이지로 이동중");
		return "membership/membershipUpdate";
	}
	
	@RequestMapping(value = "/emailConfirm.do")
	public String emailConfirm() {
		logger.info("이메일 인증으로 이동중");
		return "membership/emailConfirm";
	}
	
	@RequestMapping(value = "/memberChk.do")
	public String memberChk() {
		System.out.println("아이디 중복 확인중");	
		
		return "member/membership";
	}
	
	//아이디 중복 확인
	@RequestMapping(value = "/memberSearch.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView loginInfo(@RequestBody HashMap<String, Object> hm) throws SQLException {

		mv.setViewName("jsonView");
		try {

		boolean bol = membershipService.selectMembershipSearch(hm);

		logger.info("아이디 존재 여부는 " + bol);

		mv.addObject("bol", bol);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		return mv;
	}
	
	//멤버 등록
	@RequestMapping(value = "/memberShipInsert.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView memeberShipInsert(@RequestBody HashMap<String, Object> hm)  throws SQLException {
		mv.setViewName("jsonView");
		logger.info("받은값은"+hm);
		
		try {
		//비밀번호를 암호화하여 데이터 베이스에 저장
		String encPassword = passwordEncoder.encode(hm.get("userPw").toString());
		hm.put("userPw", encPassword);
		
		membershipService.insertMembership(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}

		return mv;
	}
	

	
	//회원정보 수정
	@RequestMapping(value = "/membershipUpdate.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView memeberShipUpdate(@RequestBody HashMap<String, Object> hm)  throws SQLException {
		mv.setViewName("jsonView");
		
		
		try {
		//비밀번호를 암호화하여 데이터 베이스에 저장
		String encPassword = passwordEncoder.encode(hm.get("userPw").toString());
		
		Authentication auth = SecurityContextHolder.getContext().getAuthentication();
        String user_id = auth.getName();

		hm.put("userPw", encPassword);
		hm.put("userId", user_id);
		
		logger.info("받은값은"+hm);
		
		membershipService.updateMembership(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}

		return mv;
	}

	//회원정보 가져오기
	@RequestMapping(value = "/memberShipSelect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView memeberShipSelect(@RequestBody HashMap<String, Object> hm)  throws SQLException {
		mv.setViewName("jsonView");
		logger.info("받은값은"+hm);
		
		try {
		
			Authentication auth = SecurityContextHolder.getContext().getAuthentication();
	        String user_id = auth.getName();
	    	hm.put("userId", user_id);
		
	        mv.addObject("data", hm);
	        HashMap map = membershipService.selectMembership(hm);
	        mv.addObject("data", map);
	        
	        mv.addObject("success", "Y");
	        
	        
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		return mv;
	}
	
	
	
	
	//회원 아이디 찾기
	@RequestMapping(value = "/membershipIdSelect.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView membershipIdSelect(@RequestBody HashMap<String, Object> hm)  throws SQLException {
		mv.setViewName("jsonView");
		logger.info("받은값은"+hm);
		
		try {
		
	        mv.addObject("data", hm);
	        HashMap map = membershipService.selectMembershipId(hm);
	        mv.addObject("data", map);
	        
	        mv.addObject("success", "Y");
	        
	        
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		return mv;
	}
	
	
	//비밀번호 변경
	@RequestMapping(value = "/changePW.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView changePw(@RequestBody HashMap<String, Object> hm)  throws SQLException {
		mv.setViewName("jsonView");
		logger.info("받은값은"+hm);
		
		try {
		//비밀번호를 암호화하여 데이터 베이스에 저장
		String encPassword = passwordEncoder.encode(hm.get("userPw").toString());
		hm.put("userPw", encPassword);
		
		membershipService.changePw(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");		
		}
  
		return mv;
	}
	
	
	//회원탈퇴
	@RequestMapping(value = "/deleteMembership.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView memeberDelete(@RequestBody HashMap<String,Object> hm)  throws SQLException{
		logger.info("게시글 수정중");
		mv.setViewName("jsonView");
		
		try {		
		logger.info("입력값은"+hm);
		
		membershipService.memeberDelete(hm);
		mv.addObject("success", "Y");
		
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");
		}
		
		return mv;
	}

}
