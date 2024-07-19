package a.a.a.ctr;

import java.text.DateFormat;
import java.util.Date;
import java.util.Locale;

import javax.servlet.http.HttpServletRequest;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.core.Authentication;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;

/**
 * Handles requests for the application home page.
 */
@Controller
public class HomeController {
	
	private static final Logger logger = LoggerFactory.getLogger(HomeController.class);
	private ModelAndView mv = new ModelAndView();
	/**
	 * Simply selects the home view to render by returning its name.
	 */
	@RequestMapping(value = "/main.do", method = RequestMethod.GET)
	public String home(Locale locale, Model model) {
		logger.info("Welcome home! The client locale is {}.", locale);
		
		Date date = new Date();
		DateFormat dateFormat = DateFormat.getDateTimeInstance(DateFormat.LONG, DateFormat.LONG, locale);
		
		String formattedDate = dateFormat.format(date);
		
		model.addAttribute("serverTime", formattedDate );
		
		return "body/main";
	}
	
	@RequestMapping(value = "/login.do", method = RequestMethod.GET)
	public String login(Locale locale, Model model) {
		return "login/login";
	}
	
	//접근제한 페이지
	@RequestMapping(value = "/accessError.do", method = { RequestMethod.GET, RequestMethod.POST })
	public String accessDenied(Authentication auth, Model model) {
		logger.info("access Denied : " + auth);
		model.addAttribute("msg","Access Denied");
		logger.info("제한된 페이지로 접근중");
		return "login/accessError";
	}
	
	
	@RequestMapping(value = "/memInfo.do", method = { RequestMethod.GET, RequestMethod.POST })
	public String memInfo() {
		return "modal/memInfo";
		
	}	

	//로그인 여부 확인
	@RequestMapping(value = "/memberChk.json", method = {RequestMethod.GET, RequestMethod.POST})
	public ModelAndView memberChk(HttpServletRequest request) {
		mv.setViewName("jsonView");
		
		boolean isAdmin= request.isUserInRole("ROLE_ADMIN");
		boolean isMember= request.isUserInRole("ROLE_MEMBER");
			
		if(isAdmin == false && isMember == false) {
			mv.addObject("success", "N");
		} else {
			mv.addObject("success", "Y");
		}
		System.out.println("mv ======" + mv);
		return mv;
	}

	
}
