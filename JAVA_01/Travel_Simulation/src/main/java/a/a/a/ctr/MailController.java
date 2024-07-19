package a.a.a.ctr;

import java.sql.SQLException;
import java.util.HashMap;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.servlet.ModelAndView;

import a.a.a.service.MailService;
import a.a.a.service.MembershipService;

@Controller
public class MailController {

	@Resource(name = "mailService")
	private MailService mailService;
	
	@Autowired
	BCryptPasswordEncoder passwordEncoder;

	private static final Logger logger = LoggerFactory.getLogger(MailController.class);
	private ModelAndView mv = new ModelAndView();
	
	
	//회원가입 인증메일
	@RequestMapping(value = "/emailConfirm.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView emailConfirm(@RequestBody HashMap<String, Object> hm) throws Exception {
		mv.setViewName("jsonView");
		logger.info("이메일 인증 중");
		try {
			boolean bol = mailService.emailCheck(hm);
			logger.info("첫번째 bol 체크"+bol);
			if (bol == false) {
				boolean bol2 = mailService.emailCheck2(hm);
				logger.info("두번째 bol 체크"+bol2);
				if(bol2 == false) {
					logger.info("최초 인증메일 발송");
					mailService.createAuthKey(hm.get("userEmail").toString(), "");
					mv.addObject("success", "Y");
				} else {
					logger.info("인증메일 재발송");
					mailService.updateAuthKey(hm.get("userEmail").toString(), "");
					mv.addObject("success", "Y");
				}
			} else {
				mv.addObject("success", "E");
				logger.info("이미 가입된 이메일 입니다");
			}
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");			
		}
		return mv;

	}
	
	//인증키 확인
	@RequestMapping(value = "/authKeyConfirm.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView authKeyConfirm(@RequestBody HashMap<String, Object> hm) throws Exception {
		mv.setViewName("jsonView");
		logger.info("받은값은"+hm);
		logger.info("인증키 확인중");
				
		try {
			
			String key = hm.get("authKey").toString();
			String encodeKey = mailService.authKeyCheck(hm);

					
			if(passwordEncoder.matches(key, encodeKey )){
				logger.info("인증키 일치");
				mv.addObject("success", "Y");
			} else {
				mv.addObject("success", "N");
					
				logger.info("인증키 불일치");
				
				logger.info("인증키가 틀렸습니다");
			}			
			
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");			
		}
		return mv;

	}
	
	//아이디 비밀번호 찾기 인증메일
	@RequestMapping(value = "/emailConfirmSearch.json", method = RequestMethod.POST)
	@ResponseBody
	public ModelAndView emailConfirmSearch(@RequestBody HashMap<String, Object> hm) throws Exception {
		mv.setViewName("jsonView");
		logger.info("이메일 인증 중");
		try {
			boolean bol = mailService.emailCheck(hm);
			logger.info("회원가입된 이메일인지 확인"+bol);
			if (bol == true) {
				mailService.updateAuthKey(hm.get("userEmail").toString(), "");
				mv.addObject("success", "Y");				
			} else {
				mv.addObject("success", "N");
				logger.info("등록되지 않은 이메일 입니다");
			}
		} catch (Exception e) {
			e.printStackTrace();
			mv.addObject("success", "N");			
		}
		return mv;
	}

}
