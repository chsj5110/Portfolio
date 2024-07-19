package a.a.a.security;

import org.springframework.security.crypto.password.PasswordEncoder;

public class CustomNoOpPasswordEncoder implements PasswordEncoder{

	@Override
	public String encode(CharSequence arg0) {
		System.out.println("before encode :"+arg0);
		return arg0.toString();
	}

	@Override
	public boolean matches(CharSequence arg0, String arg1) {
		System.out.println("matches: "+arg0 + ":" + arg1);
		return arg0.toString().equals(arg1);
	}
	
}
