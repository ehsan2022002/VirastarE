using System;
using TextRank;


namespace TextSummarize
{
    class Program
    {
        static void Main(string[] args)
        {
            var extractKeyPhrases = new ExtractKeyPhrases();
            var sentence =
                "LINCOLNSHIRE, IL With next-generation video game systems such as the Xbox One and the Playstation 4 hitting stores later this month, the console wars got even hotter today as electronics manufacturer Zenith announced the release of its own console, the Gamespace Pro, which arrives in stores Nov. 19. “With its sleek silver-and-gray box, double-analog-stick controllers, ability to play CDs, and starting price of $374.99, the Gamespace Pro is our way of saying, ‘Move over, Sony and Microsoft, Zenith is now officially a player in the console game,’” said Zenith CEO Michael Ahn at a Gamespace Pro press event, showcasing the system’s launch titles MoonChaser: Radiation, Cris Collinsworth’s Pigskin 2013, and survival-horror thriller InZomnia. “With over nine launch titles, 3D graphics, and the ability to log on to the internet using our Z-Connect technology, Zenith is finally poised to make some big waves in the video game world.” According to Zenith representatives, over 650 units have already been preordered.";
            var sentence1 =
                @"
                The US-based company has reported better-than-expected revenue numbers in the first quarter with total revenue growing 4.4 per cent to USD 122.7 billion. Its online sales grew 33 per cent in the said quarter and expects it to grow about 40 per cent for the full year.
                Walmart's net sales from international business grew 11.7 per cent to USD 30.3 billion in the said quarter. The diluted EPS stood at USD 0.72, while the adjusted EPS was at USD 1.14, the statement added.
                The statement also noted the steps taken by the company during the quarter to reposition its portfolio of businesses. These include Walmart's investment in Flipkart, combining Sainsbury and Asda in the UK and divestment of banking operations in Walmart Canada and Walmart Chile.
                On the deal with Flipkart in India, Walmart President and CEO Doug McMillon said e-commerce in India is growing rapidly and it expects the segment to grow at four times the rate of overall retail.
                ""Flipkart is already capturing a large portion of this growth and is well-positioned to accelerate into the future. So, this is an investment in a large, fast-growing country, with an innovative business positioned in the growth area of e-commerce... We're excited about what the future holds,"" he added.
                After months of discussions, Walmart had announced the mega deal to pick up 77 per cent stake in Flipkart Group holding company that is registered in Singapore. The transaction is subject to statutory approvals, including that of Competition Commission of India (CCI).
                The deal, which valued the Bengaluru-based company at USD 20.8 billion, is believed to be part of Walmart's strategy to strengthen presence in the Indian market and also compete head-on with global rival, Amazon.
                Amazon is also a rival to Flipkart and the two are locked in an intense battle for leadership in the booming Indian e-commerce market that is forecast to touch USD 200 billion in the next few years.";

            var sentance2 = @"او آن قدر از این فراز و نشیب ها را دیده که می توان شهادت داد اگر جز وضعیت کنونی سیاسی و اقتصادی و تهدیدات خارجی نبود ترجیح می داد نه کنار رییس جمهوری که در خانه و بر سفرۀ افطاری بنشیند که همسر و چشم انتظار سالهای تنهایی گسترده است. چندان که اندکی پس از زندان و در افطاری دیدم که چگونه از سیاسیون کناره می گیرد و به طعنه می گوید شماها را زیاد دیده ام. در این سال ها زنم را کم دیده ام و گوشه ای با همسرش نشست.  احمد توکلی هم دل و دماغ گذشته را ندارد. خاصه پس از داغ فرزند.برای فهم بیشتر معنای این تصویر اما کافی است به یاد آوریم در ضیافتی در 24 ساعت قبلتر به میزبانی یکی از دیگر از سران جناح راست (محمد رضا باهنر) تا محمود احمدینژاد وارد شد ناطق نوری بیرون رفت و حاضر نشدند در یک لانگ شات هم با هم باشند چه رسد که نزدیک کسانی شاید چنان خسته و نومید و دل زده یا حسب باور مرسوم همۀ سیاست را بازی بدانند و رقابت ها را جز بر سر منافع و سیاست مداران را جز دروغگویان ندانند.
                             اما اگر هم بازی باشد بازی به بازیگر نیاز دارد و چه بهتر که صحنه با رقابتهای حزبی و پارلمانی چیده شود و سیاست مداران به گفت و گو دعوت شوند تا برای وضعیتی که رییس جمهوری فعلا تنها با واژۀ «شرایط سخت» آن را توصیف می کند بهترین تدبیر اندیشیده شود. اگر چه گرایش های سیاسی اکنون بسیار متنوعتر از روزگاری است که تنها به چپ و راست تقسیم می شد و این را بهتر از هر کس این دو میدانند. ";
            

            var x= extractKeyPhrases.Extract(sentance2,");
            Console.WriteLine("Hello World!");

        }
    }
}
