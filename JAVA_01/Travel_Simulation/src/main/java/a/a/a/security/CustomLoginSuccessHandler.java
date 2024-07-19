package a.a.a.security;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.security.core.Authentication;
import org.springframework.security.web.authentication.AuthenticationSuccessHandler;

public class CustomLoginSuccessHandler implements AuthenticationSuccessHandler{
	
	private static final Logger logger = LoggerFactory.getLogger(CustomLoginSuccessHandler.class);

	@Override
	public void onAuthenticationSuccess(HttpServletRequest request, HttpServletResponse response, Authentication auth)
			throws IOException, ServletException {
		
		logger.info("로그인 성공!");
		System.out.println(request);
		List<String> roleNames = new ArrayList<>();
		
		auth.getAuthorities().forEach(authority -> {
			roleNames.add(authority.getAuthority());
		});
		
		String id= request.getParameter("userName");
		System.out.println(id);
		HttpSession session = request.getSession();
		session.setAttribute("id", id);
		logger.info((String) session.getAttribute("id"));
		
		logger.info("계정의 접근권한은 "+roleNames);
		
		if(roleNames.contains("ROLE_ADMIN")) {
			response.sendRedirect("./main.do");
			return;
		}
		
		if(roleNames.contains("ROLE_MEMBER")) {
			response.sendRedirect("./main.do");
			return;
		}
		
		response.sendRedirect("/");
		
	}
	
}
