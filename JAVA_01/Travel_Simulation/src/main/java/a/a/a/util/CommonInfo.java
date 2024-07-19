package a.a.a.util;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.UUID;

/**
 * 
 * @since 2020. 5. 13.
 * @author DS
 * 
 * --------------------------------
 *  개정이력		|| 수정자 || 수정이력
 * 2020. 5. 13. 	DS
 *
 */
public class CommonInfo {
	
	/**
	 * 
	 * @Author 		: 	DS
	 * @Daye		: 	2020. 5. 13.
	 * @Method Name	: 	getToDate
	 * @return		:	ArrayList<String> 
	 * <PRE>
	 * --------------------------------
	 * 개정이력
	 * 2020. 5. 13. DS
	 * </PRE>
	 */
	public static ArrayList<String> getToDate() {
		LocalDate date = LocalDate.now();
		ArrayList<String> dateArray = new ArrayList<String>();

		dateArray.add(Integer.toString(date.getYear()));
		dateArray.add(date.getMonthValue() < 10 ? "0" + Integer.toString(date.getMonthValue()): Integer.toString(date.getMonthValue()));
		dateArray.add(date.getDayOfMonth() < 10 ? "0" + Integer.toString(date.getDayOfMonth()): Integer.toString(date.getDayOfMonth()));

		return dateArray;

	}
	
	/**
	 * 
	 * @Author 		: 	DS
	 * @Daye		: 	2020. 5. 13.
	 * @Method Name	: 	getUuid
	 * @return		:	String 
	 * <PRE>
	 * --------------------------------
	 * 개정이력
	 * 2020. 5. 13. DS
	 * </PRE>
	 */
	public static String getUuid() {
		UUID uuid = UUID.randomUUID();

		return uuid.toString();
	}
}
