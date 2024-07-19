package a.a.a.ctr;

import java.io.IOException;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class accessDenyCotroller {
	
	private static final Logger logger = LoggerFactory.getLogger(accessDenyCotroller.class);
	
	
	@RequestMapping(value = "/deniedPage.do")
	public String register(HttpServletRequest request, HttpServletResponse response) throws IOException {
		response.sendRedirect("https://idol.st/allstars/cards/");
		return null;
	}
}
